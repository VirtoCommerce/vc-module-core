using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtoCommerce.CoreModule.Core.Seo;

public class CompositeSeoResolver : ISeoResolver
{
    private readonly IEnumerable<ISeoResolver> _resolvers;
    private readonly CompositeSeoBySlugResolver _seoBySlugResolver;

    public CompositeSeoResolver(IEnumerable<ISeoResolver> resolvers, CompositeSeoBySlugResolver seoBySlugResolver)
    {
        _resolvers = resolvers;
        _seoBySlugResolver = seoBySlugResolver;
    }

    public async Task<IList<SeoInfo>> FindSeoAsync(SeoSearchCriteria criteria)
    {
        var tasks = _resolvers.Select(x => x.FindSeoAsync(criteria)).ToArray();
        var result = (await Task.WhenAll(tasks)).SelectMany(x => x).Where(x => x.ObjectId != null && x.ObjectType != null).Distinct();
        var fallbackResults = await _seoBySlugResolver.FindSeoBySlugAsync(criteria.Slug);
        return result.Union(fallbackResults).ToList();
    }
}

