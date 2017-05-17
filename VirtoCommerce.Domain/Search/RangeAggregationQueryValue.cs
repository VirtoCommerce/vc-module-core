namespace VirtoCommerce.Domain.Search
{
    public class RangeAggregationQueryValue
    {
        public string Id { get; set; }
        public string Lower { get; set; }
        public string Upper { get; set; }
        public bool IncludeLower { get; set; }
        public bool IncludeUpper { get; set; }
    }
}
