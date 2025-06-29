using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions
{
    public abstract class CompareConditionBase : ConditionTree
    {
        public virtual string CompareCondition { get; set; } = ConditionOperation.AtLeast;

        public virtual bool UseCompareCondition(decimal leftOperand, decimal rightOperand, decimal rightSecondOperand)
        {
            bool result;

            if (CompareCondition.EqualsIgnoreCase(ConditionOperation.IsMatching) || CompareCondition.EqualsIgnoreCase(ConditionOperation.Exactly))
            {
                result = leftOperand == rightOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.IsNotMatching))
            {
                result = leftOperand != rightOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.IsGreaterThan))
            {
                result = leftOperand > rightOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.IsLessThan))
            {
                result = leftOperand < rightOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.Between))
            {
                result = leftOperand >= rightOperand && leftOperand <= rightSecondOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.AtLeast) || CompareCondition.EqualsIgnoreCase(ConditionOperation.IsGreaterThanOrEqual))
            {
                result = leftOperand >= rightOperand;
            }
            else if (CompareCondition.EqualsIgnoreCase(ConditionOperation.IsLessThanOrEqual))
            {
                result = leftOperand <= rightOperand;
            }
            else
                result = leftOperand <= rightOperand;

            return result;
        }

        public virtual bool UseCompareCondition(int leftOperand, int rightOperand, int rightSecondOperand)
        {
            var decimalLeftOperand = Convert.ToDecimal(leftOperand);
            var decimalRightOperand = Convert.ToDecimal(rightOperand);
            var decimalRightSecondOperand = Convert.ToDecimal(rightSecondOperand);
            return UseCompareCondition(decimalLeftOperand, decimalRightOperand, decimalRightSecondOperand);
        }

        public virtual bool UseCompareCondition(double leftOperand, double rightOperand, double rightSecondOperand)
        {
            var decimalLeftOperand = Convert.ToDecimal(leftOperand);
            var decimalRightOperand = Convert.ToDecimal(rightOperand);
            var decimalRightSecondOperand = Convert.ToDecimal(rightSecondOperand);
            return UseCompareCondition(decimalLeftOperand, decimalRightOperand, decimalRightSecondOperand);
        }
    }
}
