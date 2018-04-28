using System.Collections.Generic;
using System.Threading.Tasks;
using kyciti.Models;

namespace kyciti.Controllers
{
    public interface ICashedValuationService
    {
        Task<CompanyData> GetCachedValudationData(string id);
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class CashedValuationService : ICashedValuationService
    {
        private readonly Dictionary<string, CompanyData> _companyDatas = new Dictionary<string, CompanyData>();

        private readonly ICompanyValuationService _companyValuationService;

        public CashedValuationService(ICompanyValuationService companyValuationService)
        {
            _companyValuationService = companyValuationService;
        }

        public async Task<CompanyData> GetCachedValudationData(string id)
        {
            if (_companyDatas.ContainsKey(id))
            {
                return _companyDatas[id];
            }

            var companyData = await _companyValuationService.GetCompanyValuationData(id);
            _companyDatas[id] = companyData;
            return companyData;
        }
    }
}