using System.Collections.Generic;
using VirtoCommerce.CoreModule.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions
{
    public abstract class BlockConditionAndOr : ConditionTree
    {
        public bool All { get; set; }

        // Logical inverse of expression
        public bool Not { get; set; } = false;


        public override bool IsSatisfiedBy(IEvaluationContext context)
        {
            var result = false;

            if (Children != null && Children.Count > 0)
            {
                if (!Not)
                {
                    result = All ? AllSatisfied(Children, context) : AnySatisfied(Children, context);
                }
                else
                {
                    result = All ? !AllSatisfied(Children, context) : !AnySatisfied(Children, context);
                }

            }
            else
            {
                result = true;
            }

            return result;
        }

        private bool AnySatisfied(IList<IConditionTree> children, IEvaluationContext context)
        {
            foreach (var ch in children)
            {
                if (ch.IsSatisfiedBy(context)) return true;
            }
            return false;
        }

        private bool AllSatisfied(IList<IConditionTree> children, IEvaluationContext context)
        {
            foreach (var ch in children)
            {
                if (!ch.IsSatisfiedBy(context)) return false;
            }
            return true;
        }
    }


}
