using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using kyciti.Models;

namespace kyciti.Controllers
{
    public interface ICashedValuationService
    {
        Task<CompanyData> GetCachedValudationData(string companyName);
        void SetCompanyValuationData(CompanyData companyData);
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class CashedValuationService : ICashedValuationService
    {
        private readonly ConcurrentDictionary<string, CompanyData> _companyDatas =
            new ConcurrentDictionary<string, CompanyData>(StringComparer.OrdinalIgnoreCase);

        private readonly IInnocentCompanyValuationService _innocentCompanyValuationService;

        public CashedValuationService(IInnocentCompanyValuationService innocentCompanyValuationService)
        {
            _innocentCompanyValuationService = innocentCompanyValuationService;
        }

        public async Task<CompanyData> GetCachedValudationData(string companyName)
        {
            if (!_companyDatas.ContainsKey(companyName))
            {
                var companyData = await _innocentCompanyValuationService.GetCompanyValuationData(companyName);
                SetCompanyValuationData(companyData);
            }

            return _companyDatas[companyName];
        }

        public void SetCompanyValuationData(CompanyData companyData)
        {
            _companyDatas[companyData.Name] = companyData;
        }
    }
}