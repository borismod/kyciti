using System.Web.Http;
using System.Web.Http.Cors;

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
}