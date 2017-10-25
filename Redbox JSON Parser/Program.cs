using System;
using System.Collections.Generic;

namespace Redbox_JSON_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RedBoxJsonParser();

            var writer = new RedBoxDatabaseWriter(parser.RedboxMovies);
            writer.WriteAllMovies();
        }
    }
}
