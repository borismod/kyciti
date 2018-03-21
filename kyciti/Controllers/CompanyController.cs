using System.Collections.Generic;
using System.Web.Http;

namespace kyciti.Controllers
{
    public class CompanyController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET api/values/5
        public CompanyData Get(string id)
        {
            return CompanyData.GetMockData(id, false);
        }
    }
}