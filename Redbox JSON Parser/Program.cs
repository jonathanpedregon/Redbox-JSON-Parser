using System;
using System.Collections.Generic;

namespace Redbox_JSON_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RedBoxJsonParser();

            var movies = parser.RedboxMovies;

            var writer = new RedBoxDatabaseWriter(parser.RedboxMovies);
            writer.WriteAllMovies();
        }
    }
}
