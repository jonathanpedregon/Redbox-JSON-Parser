using Newtonsoft.Json;
using Redbox_JSON_Parser.Exceptions;
using System;
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
            Json = ""; //Requester.RetrieveJSON();
            if(Json.Trim().Length == 0)
            {
                var emailHandler = new ErrorEmailHandler(new EmptyJsonException());
                Environment.Exit(-2);
            }
            TrimJson();
            try
            {
                RedboxMovies = JsonConvert.DeserializeObject<List<RedboxMovie>>(Json); //jsonreaderexception
            }
            catch(JsonReaderException)
            {
                var emailHandler = new ErrorEmailHandler(new InvalidJsonException(Json));
                Environment.Exit(-1);
            }
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
