using System.Collections.Generic;
using System.Threading.Tasks;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public interface ISearchEngineService
    {
        Task<List<SearchEngineResult>> Search(string query, string keyWord);
    }

    public class SearchEngineService : ISearchEngineService
    {
        public async Task<List<SearchEngineResult>> Search(string query, string keyWord)
        {
            var bingSearch = new BingSearch();
            return await bingSearch.BingWebSearchAsync(query, keyWord);
        }
    }
}