using System;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.CoreModule.Core.Services;
using VirtoCommerce.CoreModule.Data.Repositories;

namespace VirtoCommerce.CoreModule.Data.Services
{
    public class SqlSequenceNumberGenerator : IUniqueNumberGenerator2
    {
        private readonly Func<ICoreRepository> _repositoryFactory;
        private readonly INumberGeneratorService _numberGeneratorService;
        private readonly INumberGeneratorRegistrar _numberGeneratorRegistrar;

        public SqlSequenceNumberGenerator(Func<ICoreRepository> repositoryFactory, INumberGeneratorService numberGeneratorService, INumberGeneratorRegistrar numberGeneratorRegistrar)
        {
            _repositoryFactory = repositoryFactory;
            _numberGeneratorService = numberGeneratorService;
            _numberGeneratorRegistrar = numberGeneratorRegistrar;
        }

        public async Task<string> GenerateNumber(string tenantId, string targetType)
        {
            var descriptor = await _numberGeneratorService.GetAsync(tenantId, targetType);
            if (descriptor == null)
            {
                // get from INumberGeneratorRegistrar, save to db, and create sequence
                descriptor = _numberGeneratorRegistrar.GetDescriptors().FirstOrDefault(x => x.TargetType == targetType);
                if (descriptor == null)
                {
                    throw new InvalidOperationException($"OperationType {targetType} not registered in INumberGeneratorRegistrar");
                }
                else
                {
                    descriptor.TenantId = tenantId;
                    await _numberGeneratorService.SaveChangesAsync(new[] { descriptor });
                }
            }

            using var repository = _repositoryFactory();

            // "{tenantId}_{targetType}" is incorrect: produces duplicates for same (default) templates
            // "{descriptor.Template}" results in a single Sequence (per type) for same (default) templates.
            // side effect: "Reset" would affect entire system.
            var numberInSequence = repository.GetNextSequenceValue($"{descriptor.Template}");
            return string.Format(descriptor.Template, numberInSequence, DateTime.UtcNow);
        }
    }
}
