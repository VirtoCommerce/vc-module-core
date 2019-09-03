using System.Collections.Generic;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    public class CatalogSearchCriteriaBase : SearchCriteriaBase
    {
        private string[] _catalogIds;

        public string StoreId { get; set; }

        public string CatalogId { get; set; }

        /// <summary>
        /// CategoryId1/CategoryId2, no catalog should be included in the outline
        /// </summary>
        public string Outline { get; set; }

        /// <summary>
        /// CategoryId1/CategoryId2, no catalog should be included in the outline
        /// </summary>
        public IList<string> Outlines { get; set; }

        /// <summary>
        /// Term format: name:value1,value2
        /// </summary>
        public IList<string> Terms { get; set; }

        /// <summary>
        /// Assigned groups for current user. Data format: user_groups:value1,value2
        /// </summary>
        public IList<string> UserGroups { get; set; }

        /// <summary>
        /// Enable fuzzy search, i.e. allow to search color:white even if color:wihte actually passed to criteria
        /// </summary>
        public bool IsFuzzySearch { get; set; }

        /// <summary>
        /// Gets or sets the search provider specific raw search query; all other search criteria will be ignored
        /// </summary>
        public string RawQuery { get; set; }

        public string[] CatalogIds
        {
            get
            {
                if (_catalogIds == null && !string.IsNullOrEmpty(CatalogId))
                {
                    _catalogIds = new[] { CatalogId };
                }
                return _catalogIds;
            }
            set => _catalogIds = value;
        }
    }
}
