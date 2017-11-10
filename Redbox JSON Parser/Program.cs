using System;
using System.Collections.Generic;

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
    }
}
