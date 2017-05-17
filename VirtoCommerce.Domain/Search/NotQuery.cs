namespace VirtoCommerce.Domain.Search
{
    public class NotQuery : BooleanQuery
    {
        public BaseQuery ChildQuery { get; set; }
    }
}
