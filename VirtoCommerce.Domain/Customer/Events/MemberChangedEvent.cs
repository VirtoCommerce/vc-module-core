using VirtoCommerce.Domain.Customer.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Customer.Events
{
    public class MemberChangedEvent
    {
        public MemberChangedEvent(EntryState state, Member member)
        {
            ChangeState = state;
            Member = member;
        }

        public EntryState ChangeState { get; set; }
        public Member Member { get; set; }
    }
}
