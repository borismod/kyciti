using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CompanyController : ApiController
    {
        private static readonly Dictionary<string, CompanyData> CompanyDatas = new Dictionary<string, CompanyData>();

        private readonly ICompanyDataService _companyDataService =
            new CompanyDataService(new CompanyKeyPersonsRetriever(), new CompanyStockTickerRetriever());

        // GET api/company/bezeq
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id cannot be an empty string.");
            }

            if (CompanyDatas.ContainsKey(id))
            {
                return Ok(CompanyDatas[id]);
            }

            var companyData = _companyDataService.GetCompanyData(id);
            CompanyDatas[id] = companyData;
            return Ok(companyData);
        }
    }
}