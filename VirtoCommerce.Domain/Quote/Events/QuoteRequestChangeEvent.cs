using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Quote.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Quote.Events
{
    public class QuoteRequestChangeEvent : GenericChangedEntryEvent<QuoteRequest>
    {
        [Obsolete]
        public QuoteRequestChangeEvent(EntryState state, QuoteRequest oldQuote, QuoteRequest newQuote)
            : this(new[] { new GenericChangedEntry<QuoteRequest>(newQuote, oldQuote, state) })
        {
        }
        public QuoteRequestChangeEvent(IEnumerable<GenericChangedEntry<QuoteRequest>> changedEntries)
         : base(changedEntries)
        {
        }

        [Obsolete]
        public EntryState ChangeState =>  ChangedEntries.FirstOrDefault()?.EntryState ?? EntryState.Unchanged;
        [Obsolete]
        public QuoteRequest OrigQuote => ChangedEntries.FirstOrDefault()?.OldEntry;
        [Obsolete]
        public QuoteRequest ModifiedQuote => ChangedEntries.FirstOrDefault()?.NewEntry;
    }
}
