using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuationController : ApiController
    {
        // GET api/values/5
        public CompanyData Get(string customerName)
        {
            return CompanyData.GetMockData(customerName, true);
        }
    }

    public interface IKeyWordsProvier
    {
        KeyWord[] GetKeyWords();
    }

    public class KeyWord  
    {
        public string Word { get; set; }
        public string Category { get; set; }
    }

    public interface ICompanyKeyPersonsRetriever
    {
        List<KeyPerson> GetKeyPersons(string stockTicker);
    }

    public interface ICompanyStockTickerRetriever
    {
        string GetCompanyStockTicker(string companyName);
    }
}