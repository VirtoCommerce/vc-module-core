namespace VirtoCommerce.Domain.Search
{
    public class RangeFilterValue
    {
        public string Lower { get; set; }
        public string Upper { get; set; }
        public bool IncludeLower { get; set; }
        public bool IncludeUpper { get; set; }
    }
}
