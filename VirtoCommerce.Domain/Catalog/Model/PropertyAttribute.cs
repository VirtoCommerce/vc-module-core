
using System;
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Catalog.Model
{
    public class PropertyAttribute : AuditableEntity, ICloneable
    {
        public string PropertyId { get; set; }
        public Property Property { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }

        #region ICloneable members
        public virtual object Clone()
        {
            return MemberwiseClone() as PropertyAttribute;
        }
        #endregion
    }
}
