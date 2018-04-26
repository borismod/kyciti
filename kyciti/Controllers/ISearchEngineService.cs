using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using kyciti.Engine;
using Polly;

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

            var policy = Policy.Handle<WebException>()
                .WaitAndRetryAsync(5, a => TimeSpan.FromMilliseconds(200));

            return await policy.ExecuteAsync(async () =>
                await bingSearch.BingWebSearchAsync(query, keyWord)
            );
        }
    }
}