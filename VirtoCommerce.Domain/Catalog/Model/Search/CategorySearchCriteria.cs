using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    public class CategorySearchCriteria : CatalogSearchCriteriaBase
    {
        public override string ObjectType { get; set; } = KnownDocumentTypes.Category;

        /// <summary>
        /// Specifies if we search for hidden products.
        /// </summary>
        public virtual bool WithHidden { get; set; }

    }
}
