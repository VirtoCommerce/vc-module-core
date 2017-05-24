namespace VirtoCommerce.Domain.Search
{
    public class NotFilter : IFilter
    {
        public IFilter ChildFilter { get; set; }
    }
}
