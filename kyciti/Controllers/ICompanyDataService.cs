using kyciti.Models;

namespace kyciti.Controllers
{
    public interface ICompanyDataService
    {
        CompanyData GetCompanyData(string companyName);
    }
}