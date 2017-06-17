using VirtoCommerce.Domain.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Search
{
    public class PhraseSearchCriteriaPreprocessor : ISearchCriteriaPreprocessor
    {
        private readonly ISearchPhraseParser _searchPhraseParser;

        public PhraseSearchCriteriaPreprocessor(ISearchPhraseParser searchPhraseParser)
        {
            _searchPhraseParser = searchPhraseParser;
        }

        public virtual void Process(SearchCriteria criteria)
        {
            if (!string.IsNullOrEmpty(criteria?.SearchPhrase))
            {
                var parseResult = _searchPhraseParser.Parse(criteria.SearchPhrase);
                criteria.SearchPhrase = parseResult.SearchPhrase;
                criteria.Filters.AddRange(parseResult.Filters);
            }
        }
    }
}
