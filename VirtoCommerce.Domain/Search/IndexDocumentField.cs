namespace VirtoCommerce.Domain.Search
{
    public class IndexDocumentField
    {
        public string Name { get; set; }
        public object Value { get; set; }

        // Meta information required for indexing:

        public bool IsCollection { get; set; }
        public bool IsFilterable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsRetrievable { get; set; }
    }
}
