using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace kyciti.CrunchBase
{
    internal class BingSearch
    {
        private static readonly string[] accessKeys =
        {
            "5d56a94949504ca09c8c6a42fb4f0eb6",
            "fed807af03ab4746aa88c5cd4640e4d7",
            "82fee6f2bf7d44b5bb9fdc20a277d0cb",
            "57d73ad286ee40b4b0b5e483c6011d30" 
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
            var response = (HttpWebResponse) await  request.GetResponseAsync();
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
                if (!name.Contains(keyWord) && !snippet.Contains(keyWord))
                {
                    continue;
                }

                searchResults.Add(new SearchEngineResult
                {
                    Title = name,
                    Url = url
                });
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