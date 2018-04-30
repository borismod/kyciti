using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Logging;
using kyciti.Controllers;
using log4net;

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
        private readonly ILog _log;

        private static readonly string[] OrganizationNames = { "bezeq", "apple", "microsoft", "siemens", "volkswagen", "comverse", "citigroup" };

        public ValuationInitializer(ICashedValuationService cashedValuationService, ILog log)
        {
            _cashedValuationService = cashedValuationService;
            _log = log;
        }

        public void Initialize()
        {
            using (Task task = new Task(BackgroundMethod))
            {
                task.Start();
                task.Wait();
            }
        }

        private void BackgroundMethod()
        {
            _log.Info("Start ValuationInitializer");

            Task[] cachingTasks = OrganizationNames.Select(organizationName =>
                _cashedValuationService.GetCachedValudationData(organizationName))
                .ToArray();

            Task.WaitAll(cachingTasks);

            _log.Info("Finish ValuationInitializer");
        }
    }
}