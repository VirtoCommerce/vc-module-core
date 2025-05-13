using System;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    [Obsolete("Interface is deprecated, please use ISeoResolver in SEO module instead.", DiagnosticId = "VC0011", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface ISeoBySlugResolver
    {
        Task<SeoInfo[]> FindSeoBySlugAsync(string slug);
    }
}
