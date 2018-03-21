using System.Collections.Generic;
using System.Threading.Tasks;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public interface ISearchEngineService
    {
        Task<List<SearchEngineResult>> Search(string query);
    }

    public class SearchEngineService : ISearchEngineService
    {
        public async Task<List<SearchEngineResult>> Search(string query)
        {
            var bingSearch = new BingSearch();
            return await bingSearch.BingWebSearchAsync(query);
        }
    }
}