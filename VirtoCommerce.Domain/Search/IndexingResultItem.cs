namespace VirtoCommerce.Domain.Search
{
    public class IndexingResultItem
    {
        /// <summary>
        /// Gets a value indicating whether the indexing operation succeeded for the document identified by the ID.
        /// </summary>
        public bool Succeeded { get; set; }

        /// <summary>
        /// Gets the ID of a document that was in the indexing request.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the error message explaining why the indexing operation failed for the document identified by the ID; null if indexing succeeded.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
