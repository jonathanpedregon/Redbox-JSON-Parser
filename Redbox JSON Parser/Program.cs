using System;

namespace Redbox_JSON_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new RedBoxJsonParser();

            foreach (var movie in parser.RedboxMovies) { Console.WriteLine(movie.ToString()); }

            Console.WriteLine($"Movie count: {parser.RedboxMovies.Count}");

            Console.Read();
        }
    }
}
