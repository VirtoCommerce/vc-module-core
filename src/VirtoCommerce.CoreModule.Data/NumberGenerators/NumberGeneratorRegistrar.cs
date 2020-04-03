using System;
using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Core.NumberGenerators;
using VirtoCommerce.CoreModule.Core.Services;

namespace VirtoCommerce.CoreModule.Data.NumberGenerators
{
    public class NumberGeneratorRegistrar : INumberGeneratorRegistrar
    {
        private readonly INumberGeneratorService _numberGeneratorService;

        public NumberGeneratorRegistrar(INumberGeneratorService numberGeneratorService)
        {
            _numberGeneratorService = numberGeneratorService;
        }

        public async Task RegisterType(NumberGeneratorDescriptor descriptor)
        {
            var existDescriptor = await _numberGeneratorService.GetAsync(descriptor.TenantId, descriptor.TargetType);

            if (existDescriptor != null)
            {
                throw new ArgumentException($"Descriptor '{descriptor.Template}', with TentantId: {descriptor.TenantId}, TargetType: {descriptor.TargetType} already exist");
            }

            await _numberGeneratorService.SaveChangesAsync(new[] { descriptor });

        }

        public async Task OverrideType(NumberGeneratorDescriptor descriptor)
        {
            var existDescriptor = await _numberGeneratorService.GetAsync(descriptor.TenantId, descriptor.TargetType);

            if (existDescriptor == null)
            {
                throw new ArgumentException($"Descriptor '{descriptor.Template}', with TentantId: {descriptor.TenantId}, TargetType: {descriptor.TargetType} not exist yet");
            }

            descriptor.Id = existDescriptor.Id;
            await _numberGeneratorService.SaveChangesAsync(new[] { descriptor });

        }
    }
}
