using System.Collections.Generic;
using System.Linq;
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

        public CompanyData GetCompanyValuationData(string companyName)
        {
            var stockTicker = _companyStockTickerRetriever.GetCompanyStockTicker(companyName);
            var keyPersons = _companyKeyPersonsRetriever.GetKeyPersons(stockTicker);
            KeyWord[] keyWords = _keyWordsProvier.GetKeyWords();

            var companyData = new CompanyData
            {
                Name = companyName
            };

            foreach (var keyPerson in keyPersons)
            {
                var person = new Person
                {
                    Name = $"{keyPerson.FirstName} {keyPerson.LastName}",
                    Title = keyPerson.Title
                };

                foreach (IGrouping<string, KeyWord> keyWordGroup in keyWords.GroupBy(k=>k.Category))
                {
                    List<SearchEngineResult> results = new List<SearchEngineResult>();
                    foreach (KeyWord keyWord in keyWordGroup)
                    {
                        results.AddRange(_searchEngineService.Search($"{keyPerson.FirstName} {keyPerson.LastName} {keyWord.Word}"));
                    }

                    person.Scores.Add(new PersonScore
                    {
                        Category = keyWordGroup.Key,
                        Passed = !results.Any(),
                        Sources = results
                    });

                    companyData.Members.Add(person);
                }
            }

            return companyData;
        }
    }

    public class PersonScore
    {
        public string Category { get; set; }
        public bool Passed { get; set; }
        public List<SearchEngineResult> Sources { get; set; }
    }
}