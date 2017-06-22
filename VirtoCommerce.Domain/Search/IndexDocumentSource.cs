namespace VirtoCommerce.Domain.Search
{
    public class IndexDocumentSource
    {
        public IIndexDocumentBuilder DocumentBuilder { get; set; }
        public IIndexDocumentChangesProvider ChangesProvider { get; set; }
    }
}
