using System.Collections.Generic;
using NUnit.Framework;
using Redbox_JSON_Parser;
using MySql.Data.MySqlClient;
using Redbox_JSON_Parser.Exceptions;




namespace RedBox_JSON_Crawler_Tests
{
    [TestFixture]
    public class RedBoxDatabaseWriterTests
    {
        private string SuccessfulId = "HappyPath";

        [SetUp]
        public void SetUp() { DeleteRecords(); }

        [Test]
        public void TestSuccessfulDatabaseWrite()
        {
            var redboxMovies = new List<RedboxMovie>() { new RedboxMovie(SuccessfulId, "0") };
            var writer = new RedBoxDatabaseWriter(redboxMovies);
            writer.WriteAllMovies();
            Assert.AreEqual(1, GetRecordCountById(SuccessfulId, writer.Connection));
        }

        [Test]
        public void TestUnsuccessfulConnection()
        {
            var writer = new RedBoxDatabaseWriter(new List<RedboxMovie>());
            writer.ConnectionString = "";
            Assert.Throws<MySqlException>(() => writer.Connect());
        }

        [Test]
        public void DatabaseWriteError()
        {
            var movies = new List<RedboxMovie>() { new RedboxMovie("This title id is too long", "1") };
            var writer = new RedBoxDatabaseWriter(movies);
            writer.Connect();
            Assert.Throws<DatabaseWritingException>(() => writer.WriteAllMovies());
            writer.Connection.Close();
        }
        

        [TearDown]
        public void TearDown() { DeleteRecords(); }

        public void DeleteRecords()
        {
            var writer = new RedBoxDatabaseWriter(new List<RedboxMovie>());
            writer.Connect();
            var query = $"Delete FROM redbox WHERE titleId = '{SuccessfulId}'";
            var command = new MySqlCommand(query, writer.Connection);
            command.ExecuteNonQuery();
            writer.Connection.Close();
        }

        public int GetRecordCountById(string id, MySqlConnection connection)
        {
            var query = $"SELECT COUNT(*) FROM redbox WHERE titleId = '{id}'";
            connection.Open();

            var command = new MySqlCommand(query, connection);
            var count = int.Parse(command.ExecuteScalar() + "");
            connection.Close();
            return count;
        }
    }
}
