using System.Collections.Generic;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo;

public interface ISeoResolver
{
    Task<IList<SeoInfo>> FindSeoAsync(SeoSearchCriteria criteria);
}
