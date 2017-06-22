using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    public class CatalogSearchCriteriaBase : SearchCriteriaBase
    {
        public string StoreId { get; set; }

        public string CatalogId { get; set; }

        /// <summary>
        /// CategoryId1/CategoryId2, no catalog should be included in the outline
        /// </summary>
        public string Outline { get; set; }
    }
}
