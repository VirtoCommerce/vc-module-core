using System.Threading.Tasks;
using VirtoCommerce.CoreModule.Core.NumberGenerators;

namespace VirtoCommerce.CoreModule.Core.Services
{
    public interface INumberGeneratorService
    {
        Task<NumberGeneratorDescriptor[]> GetByTenantIdAsync(string tenantId);
        Task<NumberGeneratorDescriptor> GetAsync(string tenantId, string targetType);
        Task SaveChangesAsync(NumberGeneratorDescriptor[] items);
    }
}
