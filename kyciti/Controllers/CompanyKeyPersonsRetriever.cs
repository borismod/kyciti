using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using kyciti.CrunchBase;
using log4net;

namespace kyciti.Controllers
{
    public class CompanyKeyPersonsRetriever : ICompanyKeyPersonsRetriever
    {
        private readonly ILog _logger;

        public CompanyKeyPersonsRetriever(ILog logger)
        {
            _logger = logger;
        }

        public List<KeyPerson> GetKeyPersons(string stockTicker)
        {
            string html;
            try
            {
                html = DownloadHtml(stockTicker);
            }
            catch (WebException webException)
            {
                _logger.Warn($"Could not find company {stockTicker}", webException);
                return new List<KeyPerson>();
            }
            
            html = Clean(html);

            var keyPersons = new List<KeyPerson>();

            var parts = html.Split(new[] {"<td><h2 class=\"officers\">"}, StringSplitOptions.None);
            for (var i = 1; i < parts.Length; i++)
            {
                var innerParts = parts[i].Split(new[] {"class=\"link\">"}, StringSplitOptions.None);
                if (innerParts.Length == 1)
                {
                    continue;
                }
                var name = innerParts[1].Split(new[] {"</a>"}, StringSplitOptions.None)[0];

                if (keyPersons.Any(k => k.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    continue;
                }

                var moreParts = innerParts[1].Split(new[] {"</td>"}, StringSplitOptions.None);
                var title = moreParts[3].Replace("<td>", "").Trim();

                keyPersons.Add(new KeyPerson
                    {
                        Name = name,
                        Title = title
                    }
                );
            }

            return keyPersons;
        }

        private static string DownloadHtml(string stockTicker)
        {
            string res = new WebClient()
                .DownloadString("https://www.reuters.com/finance/stocks/company-officers/" + stockTicker);
            return res;
        }

        private static string Clean(string res)
        {
            res = res.Replace("\n", "");
            res = res.Replace("\t", "");
            return res.Replace("&nbsp;", " ");
        }
    }
}