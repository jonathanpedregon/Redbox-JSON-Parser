﻿using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.Odbc;
using Redbox_JSON_Parser.Exceptions;
using System;

namespace Redbox_JSON_Parser
{
    public class RedBoxDatabaseWriter
    {
        public List<RedboxMovie> RedBoxMovies;
        private MySqlConnection Connection;
        private string ConnectionString;
        private MySqlCommand Command;

        public RedBoxDatabaseWriter(List<RedboxMovie> movies)
        {
            RedBoxMovies = movies;
        }

        public void Connect()
        {
            try
            {
                SetConnectionString();
                Connection = new MySqlConnection(ConnectionString);
                Connection.Open();
            }
            catch (MySqlException)
            {
                var errorHandler = new ErrorEmailHandler(new DatabaseConnectionException());
                Environment.Exit(-3);
            }
        }

        public void SetConnectionString()
        {
            var ConnectionStringBuilder = new MySqlConnectionStringBuilder();
            ConnectionStringBuilder.Server = "52.27.204.173";
            ConnectionStringBuilder.UserID = "screenbuddy";
            ConnectionStringBuilder.Password = "bad";//"s0ck34";
            ConnectionStringBuilder.Database = "screenbuddy_dev";
            ConnectionStringBuilder.Port = 3306;
            ConnectionString = ConnectionStringBuilder.ToString();

        }

        public void Execute(RedboxMovie movie)
        {
            var queryBuilder = new StringBuilder();
            queryBuilder.AppendLine("INSERT INTO redbox (titleId, lastSeen, soon)");
            queryBuilder.AppendLine($"VALUES('{movie.TitleId}', '{movie.LastSeen}', '{movie.Soon}')");
            var query = queryBuilder.ToString();
            Command = new MySqlCommand(query, Connection);
            Command.ExecuteNonQuery();
        }

        public void WriteAllMovies()
        {
            Connect();
            foreach (var movie in RedBoxMovies)
            {
                try
                {
                    Execute(movie);
                }
                catch (Exception)
                {
                    var errorHandler = new ErrorEmailHandler(new DatabaseWritingException(movie));
                    Connection.Close();
                    Environment.Exit(-4);
                }
            }
            Connection.Close();
        }
    }
}
