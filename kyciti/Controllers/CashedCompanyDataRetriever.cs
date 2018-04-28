using System.Collections.Generic;
using kyciti.Models;

namespace kyciti.Controllers
{
    public interface ICashedCompanyDataRetriever
    {
        CompanyData GetCashedCompanyData(string id);
    }

    // ReSharper disable once UnusedMember.Global
    public class CashedCompanyDataRetriever : ICashedCompanyDataRetriever
    {
        private readonly Dictionary<string, CompanyData> _companyDatas = new Dictionary<string, CompanyData>();

        private readonly ICompanyDataService _companyDataService;

        public CashedCompanyDataRetriever(ICompanyDataService companyDataService)
        {
            _companyDataService = companyDataService;
        }

        public CompanyData GetCashedCompanyData(string id)
        {
            if (_companyDatas.ContainsKey(id))
            {
                return _companyDatas[id];
            }

            var companyData = _companyDataService.GetCompanyData(id);
            _companyDatas[id] = companyData;

            return companyData;
        }
    }
}