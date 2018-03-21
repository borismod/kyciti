using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public class CompanyValuationService
    {
        private readonly ICompanyKeyPersonsRetriever _companyKeyPersonsRetriever;
        private readonly ICompanyStockTickerRetriever _companyStockTickerRetriever;
        private readonly IKeyWordsProvier _keyWordsProvier;
        private readonly ISearchEngineService _searchEngineService;

        public CompanyValuationService(ICompanyKeyPersonsRetriever companyKeyPersonsRetriever,
            ICompanyStockTickerRetriever companyStockTickerRetriever, IKeyWordsProvier keyWordsProvier,
            ISearchEngineService searchEngineService)
        {
            _companyKeyPersonsRetriever = companyKeyPersonsRetriever;
            _companyStockTickerRetriever = companyStockTickerRetriever;
            _keyWordsProvier = keyWordsProvier;
            _searchEngineService = searchEngineService;
        }

        public async Task<CompanyData> GetCompanyValuationData(string companyName)
        {
            var stockTicker = _companyStockTickerRetriever.GetCompanyStockTicker(companyName);
            var keyPersons = _companyKeyPersonsRetriever.GetKeyPersons(stockTicker).Take(3).ToArray();
            var keyWords = _keyWordsProvier.GetKeyWords().Take(2).ToList();

            var companyData = new CompanyData
            {
                Name = companyName
            };

            foreach (var keyWordGroup in keyWords.GroupBy(k => k.Category))
            {
                var totalPassed = 0;
                foreach (var keyPerson in keyPersons)
                {
                    var person = new Person
                    {
                        Name = $"{keyPerson.Name}",
                        Title = keyPerson.Title
                    };

                    var results = new List<SearchEngineResult>();
                    foreach (var keyWord in keyWordGroup)
                    {
                        List<SearchEngineResult> collection = await _searchEngineService.Search($"{keyPerson.Name} {keyWord.Word}");
                        results.AddRange(collection);
                    }

                    var passed = !results.Any();
                    person.Scores.Add(new PersonScore
                    {
                        Category = keyWordGroup.Key,
                        Passed = passed,
                        Sources = results
                    });

                    if (passed) totalPassed++;

                    companyData.Members.Add(person);
                    companyData.Scores.Add(new CompanyScore
                    {
                        Category = keyWordGroup.Key,
                        Score = (double)totalPassed / (double)keyPersons.Length
                    });
                }
            }

            return companyData;
        }
    }

    public class CompanyScore
    {
        public string Category { get; set; }
        public double Score { get; set; }
    }
}