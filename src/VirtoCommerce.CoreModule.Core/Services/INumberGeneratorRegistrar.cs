using System.Collections.Generic;
using VirtoCommerce.CoreModule.Core.NumberGenerators;

namespace VirtoCommerce.CoreModule.Core.Services
{
    public interface INumberGeneratorRegistrar
    {
        //Dictionary<string, NumberGeneratorDescriptor> GetDescriptorsDictionary();
        List<NumberGeneratorDescriptor> GetDescriptors();
        void RegisterDescriptor(string operationType, NumberGeneratorDescriptor descriptor);
    }
}
