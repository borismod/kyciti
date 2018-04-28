using System.Web.Http;
using System.Web.Http.Cors;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CompanyController : ApiController
    {
        private readonly ICashedCompanyDataRetriever _cashedCompanyDataRetriever;

        public CompanyController(ICashedCompanyDataRetriever cashedCompanyDataRetriever)
        {
            _cashedCompanyDataRetriever = cashedCompanyDataRetriever;
        }

        // GET api/company/bezeq
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id cannot be an empty string.");
            }

            var companyData = _cashedCompanyDataRetriever.GetCashedCompanyData(id);

            return Ok(companyData);
        }
    }
}