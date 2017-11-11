using System;
using MySql.Data.MySqlClient;
using Redbox_JSON_Parser.Exceptions;



namespace Redbox_JSON_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RedBoxJsonParser();
            parser.Execute();

            var writer = new RedBoxDatabaseWriter(parser.RedboxMovies);
            writer.WriteAllMovies();
        }

        public void WriteToDataBase(RedBoxDatabaseWriter writer)
        {
            try
            {
                writer.WriteAllMovies();
            }
            catch (MySqlException)
            {
                var errorHandler = new ErrorEmailHandler(new DatabaseConnectionException());
                writer.Connection.Close();
                Environment.Exit(-3);
            }
            catch (DatabaseWritingException ex)
            {
                var errorHandler = new ErrorEmailHandler(ex);
                writer.Connection.Close();
                Environment.Exit(-4);
            }
        }
    }
}
