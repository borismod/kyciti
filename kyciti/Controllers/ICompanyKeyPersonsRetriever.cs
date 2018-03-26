using System.Collections.Generic;
using kyciti.CrunchBase;

namespace kyciti.Controllers
{
    public interface ICompanyKeyPersonsRetriever
    {
        List<KeyPerson> GetKeyPersons(string stockTicker);
    }
}