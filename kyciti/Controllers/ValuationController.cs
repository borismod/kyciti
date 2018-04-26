using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using log4net;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuationController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger( typeof(ValuationController));

        private static readonly Dictionary<string, CompanyData> _companyDatas = new Dictionary<string, CompanyData>();
        private readonly CompanyValuationService _companyValuationService;

        public ValuationController()
        {
            _companyValuationService = new CompanyValuationService(new CompanyKeyPersonsRetriever(),
                new CompanyStockTickerRetriever(), new KeyWordsProvier(), new SearchEngineService());
        }

        // GET api/valuation/bezeq
        [HttpGet]
        public async Task<CompanyData> Get(string id)
        {
            try
            {
                if (_companyDatas.ContainsKey(id))
                {
                    return _companyDatas[id];
                }

                var companyData = await _companyValuationService.GetCompanyValuationData(id);
                _companyDatas[id] = companyData;
                return companyData;
            }
            catch (Exception exception)
            {
                Logger.Error($"Failed to valuate {id}", exception);
                throw;
            }
        }
    }
}