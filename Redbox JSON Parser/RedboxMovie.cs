using System;
using System.Text;

namespace Redbox_JSON_Parser
{
    public class RedboxMovie
    {
        public string TitleId { get; }
        public string LastSeen { get; }
        public string Soon { get; }

        public RedboxMovie(string id, string soon)
        {
            TitleId = id;
            LastSeen = DateTime.Now.ToString();
            Soon = soon;
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
