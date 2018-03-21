using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuationController : ApiController
    {
        private readonly CompanyValuationService _companyValuationService;

        public ValuationController()
        {
            _companyValuationService = new CompanyValuationService(new CompanyKeyPersonsRetriever(), new CompanyStockTickerRetriever(), new KeyWordsProvier(), new SearchEngineService());
        }

        // GET api/values/5
        [HttpGet]
        public async Task<CompanyData> Get(string id)
        {
            return await _companyValuationService.GetCompanyValuationData(id);
            // return CompanyData.GetMockData(id, true);
        }
    }
}