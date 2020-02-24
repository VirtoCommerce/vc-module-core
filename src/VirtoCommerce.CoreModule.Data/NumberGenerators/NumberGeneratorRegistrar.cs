using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.CoreModule.Core.NumberGenerators;
using VirtoCommerce.CoreModule.Core.Services;

namespace VirtoCommerce.CoreModule.Data.NumberGenerators
{
    public class NumberGeneratorRegistrar : INumberGeneratorRegistrar
    {
        private readonly List<NumberGeneratorDescriptor> _descriptors = new List<NumberGeneratorDescriptor>();


        public List<NumberGeneratorDescriptor> GetDescriptors()
        {
            return _descriptors.ToList();
        }

        public void RegisterDescriptor(string operationType, NumberGeneratorDescriptor descriptor)
        {
            _descriptors.Add(descriptor);
        }
    }
}
