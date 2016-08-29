using System;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public interface IDocument
    {
        int FieldCount { get; }
        void Add(IDocumentField field);
        void RemoveField(string name);
        bool ContainsKey(string name);
        IDocumentField this[int index] { get; }
        IDocumentField this[string name] { get; }
    }
}
