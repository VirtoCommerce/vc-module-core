namespace VirtoCommerce.Domain.Search
{
    public class GeoDistanceSortingField : SortingField
    {
        public GeoPoint Location { get; set; }
    }
}
