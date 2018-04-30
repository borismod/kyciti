using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyciti.CrunchBase;
using kyciti.Engine;
using kyciti.Models;
using log4net;

namespace kyciti.Controllers
{
    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once ClassNeverInstantiated.Global
    public class InnocentCompanyValuationService : ICompanyValuationService
    {
        private readonly ICompanyKeyPersonsRetriever _companyKeyPersonsRetriever;
        private readonly ICompanyStockTickerRetriever _companyStockTickerRetriever;
        private readonly IKeyWordsProvier _keyWordsProvier;
        private readonly ILog _log;

        public InnocentCompanyValuationService(ICompanyKeyPersonsRetriever companyKeyPersonsRetriever, 
            ICompanyStockTickerRetriever companyStockTickerRetriever, 
            IKeyWordsProvier keyWordsProvier, 
            ILog log)
        {
            _companyKeyPersonsRetriever = companyKeyPersonsRetriever;
            _companyStockTickerRetriever = companyStockTickerRetriever;
            _keyWordsProvier = keyWordsProvier;
            _log = log;
        }

        public Task<CompanyData> GetCompanyValuationData(string companyName)
        {
            _log.Info($"Start valuation for {companyName}");

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
                foreach (var keyPerson in keyPersons)
                {
                    var person = GetPerson(keyPerson, companyData);

                    var personScore = new PersonScore
                    {
                        Category = keyWordGroup.Key,
                        Passed = true,
                        Sources = new List<SearchEngineResult>()
                    };

                    person.Scores.Add(personScore);
                }

                companyData.Scores.Add(new CompanyScore
                {
                    Category = keyWordGroup.Key,
                    Score = 0
                });
            }

            foreach (var companyDataMember in companyData.Members)
            {
                companyDataMember.TotalScore = companyDataMember.Scores.Count(s => !s.Passed);
            }

            var totalFailures = companyData.Members.Sum(m => m.TotalScore);
            var maxRisk = companyData.Members.Count * companyData.Scores.Count;
            companyData.TotalScore = 100.0 *  totalFailures / maxRisk;

            _log.Info($"Finish valuation for {companyName} score {companyData.TotalScore}");

            return Task.FromResult(companyData);
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