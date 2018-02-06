using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Catalog.Model.Search
{
    public class ProductAssociationSearchCriteria : SearchCriteriaBase
    {
        public string Group { get; set; }
        public string[] Tags;
    }
}
