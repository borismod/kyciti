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
        private readonly ILog _logger;
        private readonly ICashedValuationService _cashedValuationService;

        public ValuationController(ICashedValuationService cashedValuationService, ILog logger)
        {
            _cashedValuationService = cashedValuationService;
            _logger = logger;
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
                _logger.Error($"Failed to valuate {id}", exception);
                throw;
            }
        }
    }
}