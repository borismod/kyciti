using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kyciti.CrunchBase
{
    internal class BingSearch
    {
        private static readonly string accessKey = "5d56a94949504ca09c8c6a42fb4f0eb6";
        private static readonly string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";

        public List<SearchEngineResult> BingWebSearch(string searchQuery)
        {
            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString(searchQuery);
            var request = WebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = accessKey;
            var response = (HttpWebResponse) request.GetResponseAsync().Result;
            var json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            var pages = (JArray) obj["webPages"]["value"];
            List<SearchEngineResult> searchResults = new List<SearchEngineResult>();
            foreach (dynamic item in pages)
            {
                var name = item["name"].ToString();
                var url = item["url"].ToString();

                searchResults.Add(new SearchEngineResult()
                {
                    Title = name,
                    Url = url
                });
            }

            return searchResults;
        }
    }
}