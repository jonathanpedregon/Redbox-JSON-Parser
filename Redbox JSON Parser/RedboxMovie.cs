using System;
using System.Text;

namespace Redbox_JSON_Parser
{
    public class RedboxMovie
    {
        public string TitleId { get; }
        public string Title { get; }
        public string LastSeen { get; }
        public string Soon { get; }
        public string Year { get; }

        public RedboxMovie(string name, string soon, string sortDate)
        {
            Title = name;
            LastSeen = DateTime.Now.ToString();
            Soon = soon;
            Year = sortDate.Substring(0, 4);
        }

        public override string ToString()
        {
            var movieSB = new StringBuilder();
            movieSB.AppendLine($"ID: {TitleId.ToString()}");
            movieSB.AppendLine($"LastSeen: {LastSeen.ToString()}");
            movieSB.AppendLine($"Soon: {Soon}");
            return movieSB.ToString();
        }
    }
}
