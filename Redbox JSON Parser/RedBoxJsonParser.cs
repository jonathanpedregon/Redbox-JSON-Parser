using Newtonsoft.Json;
using System.Collections.Generic;

namespace Redbox_JSON_Parser
{
    class RedBoxJsonParser
    {
        private RedboxWebRequester Requester;
        private string Json;
        public List<RedboxMovie> RedboxMovies { get; set; }

        public RedBoxJsonParser()
        {
            Requester = new RedboxWebRequester();
            CreateRedBoxMovies();
        }

        public void CreateRedBoxMovies()
        {
            Json = Requester.RetrieveJSON();
            TrimJson();
            RedboxMovies = JsonConvert.DeserializeObject<List<RedboxMovie>>(Json);
        }

        public void TrimJson()
        {
            var stringsToRemove = new List<string>() { "var __titles = ", ";" };

            foreach (var stringToRemove in stringsToRemove)
            {
                Json = Json.Replace(stringToRemove, "");
            }
        }
    }
}
