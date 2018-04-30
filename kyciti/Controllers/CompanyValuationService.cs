using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kyciti.CrunchBase;
using kyciti.Engine;
using kyciti.Models;
using log4net;

namespace kyciti.Controllers
{
    public interface ICompanyValuationService
    {
        Task<CompanyData> GetCompanyValuationData(string companyName);
    }

    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once ClassNeverInstantiated.Global
    public class CompanyValuationService : ICompanyValuationService
    {
        private readonly ICompanyKeyPersonsRetriever _companyKeyPersonsRetriever;
        private readonly ICompanyStockTickerRetriever _companyStockTickerRetriever;
        private readonly IKeyWordsProvier _keyWordsProvier;
        private readonly IPersonEvaluationService _personEvaluationService;
        private readonly ILog _log;

        public CompanyValuationService(ICompanyKeyPersonsRetriever companyKeyPersonsRetriever,
            ICompanyStockTickerRetriever companyStockTickerRetriever,
            IKeyWordsProvier keyWordsProvier,
            IPersonEvaluationService personEvaluationService, 
            ILog log)
        {
            _companyKeyPersonsRetriever = companyKeyPersonsRetriever;
            _companyStockTickerRetriever = companyStockTickerRetriever;
            _keyWordsProvier = keyWordsProvier;
            _personEvaluationService = personEvaluationService;
            _log = log;
        }

        public async Task<CompanyData> GetCompanyValuationData(string companyName)
        {
            _log.Info($"Start valuation for {companyName}");

            var stockTicker = _companyStockTickerRetriever.GetCompanyStockTicker(companyName);
            var keyPersons = _companyKeyPersonsRetriever.GetKeyPersons(stockTicker).Take(10).ToArray();
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
                        List<SearchEngineResult> collection = await _personEvaluationService.EvaluatePersonAsync(keyPerson.Name, keyWord.Word);
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

                var nubmerOfFailed = keyPersons.Count() - totalPassed;

                companyData.Scores.Add(new CompanyScore
                {
                    Category = keyWordGroup.Key,
                    Score = nubmerOfFailed
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