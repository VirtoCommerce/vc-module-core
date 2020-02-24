using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Common
{
    public interface IUniqueNumberGenerator2
    {
        /// <summary>
        /// Generates unique number for the specified tenant and target type
        /// </summary>
        /// <param name="tenantId">The tenant (store) to generate the number for</param>
        /// <param name="targetType">Target type to generate the number for, e.g., Order, Payment, Quote</param>
        /// <returns>Generated number</returns>
        Task<string> GenerateNumber(string tenantId, string targetType);
    }
}
