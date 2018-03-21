using System.Web.Http;
using System.Web.Http.Cors;

namespace kyciti.Controllers
{
    [EnableCors("*", "*", "*")]
    public class CompanyController : ApiController
    {
        // GET api/values/bezeq
        public CompanyData Get(string id)
        {
            return CompanyData.GetMockData(id, false);
        }
    }
}