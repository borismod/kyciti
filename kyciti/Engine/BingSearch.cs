using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using kyciti.CrunchBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kyciti.Engine
{
    internal class BingSearch
    {
        private static readonly string[] accessKeys =
        {
            "bdf8e530eb0a4af2bc839a6bc5fce1db",
            "64a0684cac9143df89920218060b5b67"
        };

        private static readonly string uriBase = "https://api.cognitive.microsoft.com/bing/v7.0/search";
        private readonly Random _random;

        public BingSearch()
        {
            _random = new Random();
        }

        public async Task<List<SearchEngineResult>> BingWebSearchAsync(string searchQuery, string keyWord)
        {
            Thread.Sleep(500);

            var uriQuery = uriBase + "?q=" + Uri.EscapeDataString($"{searchQuery} {keyWord}");
            var request = WebRequest.Create(uriQuery);
            request.Headers["Ocp-Apim-Subscription-Key"] = GetAccessKey();
            var response = (HttpWebResponse) await request.GetResponseAsync();
            var json = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            var webPages = obj["webPages"];
            if (webPages == null)
            {
                return new List<SearchEngineResult>();
            }
            var pages = (JArray) webPages["value"];
            List<SearchEngineResult> searchResults = new List<SearchEngineResult>();
            foreach (dynamic item in pages)
            {
                var name = item["name"].ToString();
                var url = item["url"].ToString();
                var snippet = item["snippet"].ToString();

                if ( (name.Contains(keyWord) || snippet.Contains(keyWord))
                    && (name.Contains(searchQuery) || snippet.Contains(searchQuery)))
                {
                    searchResults.Add(new SearchEngineResult
                    {
                        Title = name,
                        Snippet = snippet,
                        Url = url
                    });
                }
            }

            return searchResults;
        }

        private string GetAccessKey()
        {
            var accessKeyIndex = _random.Next(accessKeys.Length - 1);
            return accessKeys[accessKeyIndex];
        }
    }
}