using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo;

public interface ISeoResolver
{
    Task<SeoInfo[]> FindSeoAsync(SeoSearchCriteria criteria);
}
