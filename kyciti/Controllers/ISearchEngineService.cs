using System.Collections.Generic;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public interface ISearchEngineService
    {
        List<SearchEngineResult> Search(string query);
    }

    public class SearchEngineService : ISearchEngineService
    {
        public List<SearchEngineResult> Search(string query)
        {
            var bingSearch = new BingSearch();
            return bingSearch.BingWebSearch(query);
        }
    }
}