using System;
using System.Net;

namespace kyciti.Controllers
{
    public class CompanyStockTickerRetriever : ICompanyStockTickerRetriever
    {
        public string GetCompanyStockTicker(string companyName)
        {
            var namesRes = new WebClient().DownloadString("https://www.reuters.com/finance/stocks/lookup?searchType=any&search=" + companyName);
            namesRes = Clean(namesRes);
            var nameParts = namesRes.Split(new string[] { "<div class=\"search-companies-count\">" }, StringSplitOptions.None);
            if (nameParts.Length == 1)
                return null;
            var rowParts = nameParts[1].Split(new[] { "</tr>" }, StringSplitOptions.None);
            return rowParts[1].Split(new[] { "<td>" }, StringSplitOptions.None)[2].Replace("</td>", "");
        }

        private static string Clean(string res) {
            res = res.Replace("\n", "");
            res = res.Replace("\t", "");
            res = res.Replace("\r", "");
            return res.Replace("&nbsp;", " ");
        } 
    }
}