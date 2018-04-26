using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyciti.CrunchBase;
using kyciti.Engine;

namespace kyciti.Controllers
{
    public class CompanyValuationService
    {
        private readonly ICompanyKeyPersonsRetriever _companyKeyPersonsRetriever;
        private readonly ICompanyStockTickerRetriever _companyStockTickerRetriever;
        private readonly IKeyWordsProvier _keyWordsProvier;
        private readonly ISearchEngineService _searchEngineService;

        public CompanyValuationService(ICompanyKeyPersonsRetriever companyKeyPersonsRetriever,
            ICompanyStockTickerRetriever companyStockTickerRetriever,
            IKeyWordsProvier keyWordsProvier,
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
            var keyPersons = _companyKeyPersonsRetriever.GetKeyPersons(stockTicker).ToArray();
            var keyWords = _keyWordsProvier.GetKeyWords();

            var companyData = new CompanyData
            {
                Name = companyName,
                Category = "Corporate"
            };

            foreach (var keyWordGroup in keyWords.GroupBy(k => k.Category))
            {
                var totalPassed = 0;
                foreach (var keyPerson in keyPersons)
                {
                    var person = GetPerson(keyPerson, companyData);

                    var results = new List<SearchEngineResult>();
                    foreach (var keyWord in keyWordGroup)
                    {
                        var collection = await _searchEngineService.Search(keyPerson.Name, keyWord.Word);
                        results.AddRange(collection);
                    }

                    var passed = !results.Any();
                    var personScore = new PersonScore
                    {
                        Category = keyWordGroup.Key,
                        Passed = passed,
                        Sources = results
                    };

                    person.Scores.Add(personScore);

                    if (passed) totalPassed++;
                }

                companyData.Scores.Add(new CompanyScore
                {
                    Category = keyWordGroup.Key,
                    // number of failed
                    Score = keyPersons.Count() - totalPassed
                });
            }

            foreach (var companyDataMember in companyData.Members)
            {
                companyDataMember.TotalScore = companyDataMember.Scores.Count(s => !s.Passed);
            }

            var totalFailures = companyData.Members.Sum(m => m.TotalScore);
            var maxRisk = companyData.Members.Count * companyData.Scores.Count;
            companyData.TotalScore = 100.0 *  totalFailures / maxRisk;

            return companyData;
        }

        private static Person GetPerson(KeyPerson keyPerson, CompanyData companyData)
        {
            var existingPerson = companyData.Members.FirstOrDefault(p => p.Name == keyPerson.Name);

            if (existingPerson != null)
            {
                return existingPerson;
            }

            var person = new Person
            {
                Name = keyPerson.Name,
                Title = keyPerson.Title
            };

            companyData.Members.Add(person);

            return person;
        }
    }
}