using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Data.Indexing.BackgroundJobs
{
    public class IndexEntry
    {
        public IndexEntry()
        {
        }

        public IndexEntry(string id, string type, EntryState entryState)
        {
            Id = id;
            Type = type;
            EntryState = entryState;
        }

        public string Id { get; set; }
        public string Type { get; set; }
        public EntryState EntryState { get; set; }
    }
}
