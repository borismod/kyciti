using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using kyciti.Models;
using log4net;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ValuationController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger( typeof(ValuationController));

        private readonly ICashedValuationService _cashedValuationService;

        public ValuationController(ICashedValuationService cashedValuationService)
        {
            _cashedValuationService = cashedValuationService;
        }

        // GET api/valuation/bezeq
        [HttpGet]
        public async Task<CompanyData> Get(string id)
        {
            try
            {
                return await _cashedValuationService.GetCachedValudationData(id);
            }
            catch (Exception exception)
            {
                Logger.Error($"Failed to valuate {id}", exception);
                throw;
            }
        }
    }
}