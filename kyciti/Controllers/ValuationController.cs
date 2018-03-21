using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuationController : ApiController
    {
        private static readonly Dictionary<string, CompanyData> _companyDatas = new Dictionary<string, CompanyData>();
        private readonly CompanyValuationService _companyValuationService;

        public ValuationController()
        {
            _companyValuationService = new CompanyValuationService(new CompanyKeyPersonsRetriever(),
                new CompanyStockTickerRetriever(), new KeyWordsProvier(), new SearchEngineService());
        }

        // GET api/values/5
        [HttpGet]
        public async Task<CompanyData> Get(string id)
        {
            if (_companyDatas.ContainsKey(id))
            {
                return _companyDatas[id];
            }

            var companyData = await _companyValuationService.GetCompanyValuationData(id);
            _companyDatas[id] = companyData;
            return companyData;
        }
    }
}