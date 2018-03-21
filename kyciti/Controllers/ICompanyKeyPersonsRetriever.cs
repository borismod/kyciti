using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public interface ICompanyKeyPersonsRetriever
    {
        List<KeyPerson> GetKeyPersons(string stockTicker);
    }

    public class CompanyKeyPersonsRetriever : ICompanyKeyPersonsRetriever
    {
        public List<KeyPerson> GetKeyPersons(string stockTicker)
        {
            var res = new WebClient()
                .DownloadString("https://www.reuters.com/finance/stocks/company-officers/" + stockTicker).ToLower();
            res = Clean(res);

            var keyPersons = new List<KeyPerson>();

            var parts = res.Split(new[] {"<td><h2 class=\"officers\">"}, StringSplitOptions.None);
            for (var i = 1; i < parts.Length; i++)
            {
                var innerParts = parts[i].Split(new[] {"class=\"link\">"}, StringSplitOptions.None);
                if (innerParts.Length == 1)
                    continue;
                var name = innerParts[1].Split(new[] {"</a>"}, StringSplitOptions.None)[0];

                if (keyPersons.Any(k => k.Name == name))
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

        private static string Clean(string res)
        {
            res = res.Replace("\n", "");
            res = res.Replace("\t", "");
            return res.Replace("&nbsp;", " ");
        }
    }
}