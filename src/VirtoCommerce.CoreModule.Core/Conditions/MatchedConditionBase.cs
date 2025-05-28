using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions
{
    public abstract class MatchedConditionBase : ConditionTree
    {
        public string Value { get; set; }
        public string MatchCondition { get; set; } = ConditionOperation.Contains;

        public virtual bool UseMatchedCondition(string leftOperand)
        {
            if (string.IsNullOrEmpty(leftOperand))
            {
                return false;
            }

            bool result;
            if (MatchCondition.EqualsIgnoreCase(ConditionOperation.Contains))
            {
                result = leftOperand.ContainsIgnoreCase(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.Matching))
            {
                result = leftOperand.EqualsIgnoreCase(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.ContainsCase))
            {
                result = leftOperand.Contains(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.MatchingCase))
            {
                result = leftOperand.Equals(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.NotContains))
            {
                result = !leftOperand.ContainsIgnoreCase(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.NotMatching))
            {
                result = !leftOperand.EqualsIgnoreCase(Value);
            }
            else if (MatchCondition.EqualsIgnoreCase(ConditionOperation.NotContainsCase))
            {
                result = !leftOperand.Contains(Value);
            }
            else
            {
                result = !leftOperand.Equals(Value);
            }

            return result;
        }
    }
}
