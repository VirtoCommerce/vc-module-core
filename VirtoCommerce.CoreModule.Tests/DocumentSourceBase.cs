using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Search;

namespace VirtoCommerce.CoreModule.Tests
{
    public abstract class DocumentSourceBase : IIndexDocumentChangesProvider, IIndexDocumentBuilder
    {
        public abstract IList<IndexDocument> Documents { get; }
        public abstract IList<IndexDocumentChange> Changes { get; }

        public virtual Task<long> GetTotalChangesCountAsync(DateTime? startDate, DateTime? endDate)
        {
            long result;

            if (startDate == null && endDate == null)
            {
                result = Documents.Count;
            }
            else
            {
                result = GetChangesQuery(startDate, endDate).Count();
            }

            return Task.FromResult(result);
        }

        public virtual Task<IList<IndexDocumentChange>> GetChangesAsync(DateTime? startDate, DateTime? endDate, long skip, long take)
        {
            IList<IndexDocumentChange> result;

            if (startDate == null && endDate == null)
            {
                result = Documents.Select(d => new IndexDocumentChange
                {
                    DocumentId = d.Id,
                    ChangeType = IndexDocumentChangeType.Modified,
                    ChangeDate = DateTime.UtcNow
                })
                .Skip((int)skip)
                .Take((int)take)
                .ToArray();
            }
            else
            {
                var changes = GetChangesQuery(startDate, endDate);
                result = changes.Skip((int)skip).Take((int)take).ToArray();
            }
            return Task.FromResult(result);
        }

        public virtual Task<IList<IndexDocument>> GetDocumentsAsync(IList<string> documentIds)
        {
            IList<IndexDocument> result = Documents.Where(d => documentIds.Contains(d.Id)).ToArray();
            return Task.FromResult(result);
        }


        protected static IndexDocument CreateDocument(string id, string fieldname)
        {
            var result = new IndexDocument(id);
            result.Add(new IndexDocumentField(fieldname, id));
            return result;
        }

        protected virtual IQueryable<IndexDocumentChange> GetChangesQuery(DateTime? startDate, DateTime? endDate)
        {
            var result = Changes.AsQueryable();

            if (startDate != null)
            {
                result = result.Where(c => c.ChangeDate >= startDate.Value);
            }

            if (endDate != null)
            {
                result = result.Where(c => c.ChangeDate <= endDate.Value);
            }

            return result;
        }
    }
}
