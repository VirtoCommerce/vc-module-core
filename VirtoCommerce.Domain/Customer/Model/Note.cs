using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Customer.Model
{
    public class Note : AuditableEntity, ICloneable
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }
    }
}
