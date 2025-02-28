using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.CoreModule.Core.Common;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.CoreModule.Core.Conditions
{
    public abstract class ConditionTree : ValueObject, IConditionTree
    {
        protected ConditionTree()
        {
            Id = GetType().Name;
        }

        //Id plays role of type name (discriminator)
        //TODO: rename in future to something else
        public string Id { get; protected set; }

        public virtual IList<IConditionTree> AvailableChildren { get; set; } = new List<IConditionTree>();
        public virtual IList<IConditionTree> Children { get; set; } = new List<IConditionTree>();

        public ConditionTree WithAvailableChildren(params IConditionTree[] availableChildren)
        {
            ArgumentNullException.ThrowIfNull(availableChildren);
            AvailableChildren.AddRange(availableChildren);
            return this;
        }

        [Obsolete("Use WithAvailableChildren()", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
        public ConditionTree WithAvailConditions(params IConditionTree[] availConditions)
        {
            ArgumentNullException.ThrowIfNull(availConditions);
            AvailableChildren.AddRange(availConditions);
            return this;
        }

        public ConditionTree WithChildren(params IConditionTree[] children)
        {
            ArgumentNullException.ThrowIfNull(children);
            Children.AddRange(children);
            return this;
        }

        [Obsolete("Use WithChildren()", DiagnosticId = "VC0010", UrlFormat = "https://docs.virtocommerce.org/products/products-virto3-versions/")]
        public ConditionTree WithChildrens(params IConditionTree[] childrenCondition)
        {
            ArgumentNullException.ThrowIfNull(childrenCondition);
            Children.AddRange(childrenCondition);
            return this;
        }

        public override object Clone()
        {
            var result = (ConditionTree)base.Clone();
            result.Children = Children?.Select(x => x.Clone() as IConditionTree).ToList();
            result.AvailableChildren = AvailableChildren?.Select(x => x.Clone() as IConditionTree).ToList();
            return result;
        }

        public virtual void MergeFromPrototype(IConditionTree prototype)
        {
            ArgumentNullException.ThrowIfNull(prototype);

            void mergeFromPrototype(IEnumerable<IConditionTree> sourceList, ICollection<IConditionTree> targetList)
            {
                foreach (var source in sourceList)
                {
                    var existTargets = targetList.Where(x => x.Id.EqualsInvariant(source.Id)).ToList();
                    if (existTargets.Count > 0)
                    {
                        foreach (var target in existTargets)
                        {
                            target.MergeFromPrototype(source);
                        }
                    }
                    else
                    {
                        targetList.Add(source);
                    }
                }
            }

            if (prototype.AvailableChildren != null)
            {
                AvailableChildren ??= new List<IConditionTree>();
                mergeFromPrototype(prototype.AvailableChildren, AvailableChildren);
            }

            if (prototype.Children != null)
            {
                Children ??= new List<IConditionTree>();
                mergeFromPrototype(prototype.Children, Children);
            }
        }

        public virtual bool IsSatisfiedBy(IEvaluationContext context)
        {
            return true;
        }
    }
}
