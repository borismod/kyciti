using System.IO;
using System.Linq;
using System.Reflection;
using kyciti.Controllers;
using kyciti.Models;
using log4net;
using Newtonsoft.Json;
using WebGrease.Css.Extensions;

namespace kyciti
{
    public interface IValuationInitializer
    {
        void Initialize();
    }

    // ReSharper disable once UnusedMember.Global
    public class ValuationInitializer : IValuationInitializer
    {
        private readonly ICashedValuationService _cashedValuationService;
        private readonly Assembly _currentAssembly = typeof(ValuationInitializer).Assembly;

        private readonly ILog _log;

        public ValuationInitializer(ICashedValuationService cashedValuationService, ILog log)
        {
            _cashedValuationService = cashedValuationService;
            _log = log;
        }

        public void Initialize()
        {
            _log.Info("Start Initialize");

            _currentAssembly
                .GetManifestResourceNames()
                .Where(r => r.StartsWith("kyciti.Data") && r.EndsWith(".json")).ToArray()
                .Select(r => _currentAssembly.GetManifestResourceStream(r))
                .ForEach(SetCompanyValuationData);

            _log.Info("Finish Initialize");
        }

        private void SetCompanyValuationData(Stream stream)
        {
            stream.Seek(0L, SeekOrigin.Begin);
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                var companyData = JsonConvert.DeserializeObject<CompanyData>(content);

                _cashedValuationService.SetCompanyValuationData(companyData);

                _log.Info($"Loaded from cache {companyData.Name}");
            }
        }
    }
}