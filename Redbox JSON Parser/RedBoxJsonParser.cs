using Newtonsoft.Json;
using Redbox_JSON_Parser.Exceptions;
using System;
using System.Collections.Generic;

namespace Redbox_JSON_Parser
{
    public class RedBoxJsonParser
    {
        private RedboxWebRequester Requester;
        public string Json;
        public List<RedboxMovie> RedboxMovies { get; set; }

        public RedBoxJsonParser()
        {
            Requester = new RedboxWebRequester();
        }

        public void Execute()
        {
            Json = Requester.RetrieveJSON();
            try
            {
                CreateRedBoxMovies();
            }
            catch (JsonReaderException)
            {
                var emailHandler = new ErrorEmailHandler(new InvalidJsonException(Json));
                Environment.Exit(-1);
            }
            catch (EmptyJsonException)
            {
                var emailHandler = new ErrorEmailHandler(new EmptyJsonException());
                Environment.Exit(-2);
            }
        }

        public void CreateRedBoxMovies()
        {
            if (Json.Trim().Length == 0)
            {
                throw new EmptyJsonException();
            }
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
