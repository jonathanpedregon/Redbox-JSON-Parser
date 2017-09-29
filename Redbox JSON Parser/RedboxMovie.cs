using System.Text;

namespace Redbox_JSON_Parser
{
    class RedboxMovie
    {
        private string ID;
        private string Name;

        public RedboxMovie(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            var movieSB = new StringBuilder();
            movieSB.AppendLine($"ID: {ID}");
            movieSB.AppendLine($"Name: {Name}");
            return movieSB.ToString();
        }
    }
}
