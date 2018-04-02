using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Common.Events;
using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Customer.Events
{
    public class MemberChangingEvent : GenericChangedEntryEvent<Member>
    {
        [Obsolete]
        public MemberChangingEvent(EntryState state, Member member)
            : this(new[] { new GenericChangedEntry<Member>(member, member, state) })
        {
        }

        public MemberChangingEvent(IEnumerable<GenericChangedEntry<Member>> changedEntries)
            : base(changedEntries)
        {
        }

        [Obsolete]
        public EntryState ChangeState => ChangedEntries.FirstOrDefault()?.EntryState ?? EntryState.Unchanged;
        [Obsolete]
        public Member Member => ChangedEntries.FirstOrDefault().NewEntry;
    }
}
