using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Core.NumberGenerators;

namespace VirtoCommerce.CoreModule.Core.Services
{
    public interface INumberGeneratorRegistrar
    {
        Task RegisterType(NumberGeneratorDescriptor descriptor);

        Task OverrideType(NumberGeneratorDescriptor descriptor);
    }
}
