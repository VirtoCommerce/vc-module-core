using System;
using System.Linq;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions
{
    public class UserGroupIsCondition : ConditionTree
    {
        public string[] Groups { get; set; }

        /// <summary>
        ///  ((EvaluationContextBase)x).UserGroupsContains
        /// </summary>
        public override bool IsSatisfiedBy(IEvaluationContext context)
        {
            var result = false;
            if (context is EvaluationContextBase evaluationContextBase && !Groups.IsNullOrEmpty())
            {
                result = evaluationContextBase.UserGroups != null;
                if (result)
                {
                    result = evaluationContextBase.UserGroups
                        .Any(x => Groups.Any(group => string.Equals(x, group, StringComparison.InvariantCultureIgnoreCase)));
                }
            }

            return result;
        }

    }
}
