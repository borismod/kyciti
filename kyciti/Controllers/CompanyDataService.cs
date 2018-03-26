using System.Linq;

namespace kyciti.Controllers
{
    public class CompanyDataService : ICompanyDataService
    {
        private readonly ICompanyKeyPersonsRetriever _companyKeyPersonsRetriever;
        private readonly ICompanyStockTickerRetriever _companyStockTickerRetriever;

        public CompanyDataService(ICompanyKeyPersonsRetriever companyKeyPersonsRetriever, ICompanyStockTickerRetriever companyStockTickerRetriever)
        {
            _companyKeyPersonsRetriever = companyKeyPersonsRetriever;
            _companyStockTickerRetriever = companyStockTickerRetriever;
        }

        public CompanyData GetCompanyData(string companyName)
        {
            var stockTicker = _companyStockTickerRetriever.GetCompanyStockTicker(companyName);
            var keyPersons = _companyKeyPersonsRetriever.GetKeyPersons(stockTicker);
            var members = keyPersons.Select(p => new Person
            {
                Name = p.Name,
                Title = p.Title
            }).ToList();

            return new CompanyData
            {
                Name = companyName,
                Category = "Corporate",
                Members = members
            };
        }
    }
}