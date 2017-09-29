using System.IO;
using System.Net;

namespace Redbox_JSON_Parser
{
    class RedboxWebRequester
    {
        public static string Url = "http://www.redbox.com/api/product/js/__titles";

        public string RetrieveJSON()
        {
            string results;
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";

            var response = (HttpWebResponse)request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                results = reader.ReadToEnd();
            }
            return results;
        }
    }
}
