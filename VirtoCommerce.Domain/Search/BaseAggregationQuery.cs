namespace VirtoCommerce.Domain.Search
{
    public class BaseAggregationQuery
    {
        public string Id { get; set; }
        public string FieldName { get; set; }
        public BaseQuery Filter { get; set; }
    }
}
