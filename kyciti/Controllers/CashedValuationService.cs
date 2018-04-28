using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using kyciti.Models;

namespace kyciti.Controllers
{
    public interface ICashedValuationService
    {
        Task<CompanyData> GetCachedValudationData(string companyName);
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class CashedValuationService : ICashedValuationService
    {
        private readonly ConcurrentDictionary<string, CompanyData> _companyDatas =
            new ConcurrentDictionary<string, CompanyData>(StringComparer.OrdinalIgnoreCase);

        private readonly ICompanyValuationService _companyValuationService;

        public CashedValuationService(ICompanyValuationService companyValuationService)
        {
            _companyValuationService = companyValuationService;
        }

        public async Task<CompanyData> GetCachedValudationData(string companyName)
        {
            if (!_companyDatas.ContainsKey(companyName))
            {
                var companyData = await _companyValuationService.GetCompanyValuationData(companyName);
                _companyDatas[companyName] = companyData;
            }

            return _companyDatas[companyName];
        }
    }
}