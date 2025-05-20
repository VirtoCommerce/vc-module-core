using System;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo
{
    [Obsolete("Use Use VirtoCommerce.Seo.Core.Services.ISeoResolver", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
    public interface ISeoBySlugResolver
    {
        Task<SeoInfo[]> FindSeoBySlugAsync(string slug);
    }
}
