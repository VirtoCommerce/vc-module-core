using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    /// <summary>
    /// Represents property validation rules definition
    /// </summary>
    public class PropertyValidationRule : Entity, ICloneable
    {
        /// <summary>
        /// Uniquie value flag constrain
        /// </summary>
        public bool IsUnique { get; set; }

        /// <summary>
        /// Down chars count border or null if no defined
        /// </summary>
        public int? CharCountMin { get; set; }

        /// <summary>
        /// Upper chars count border or null if no defined
        /// </summary>
        public int? CharCountMax { get; set; }
        /// <summary>
        /// Custom regular expression
        /// </summary>
        public string RegExp { get; set; }

        public string PropertyId { get; set; }

        public Property Property { get; set; }

        #region ICloneable members

        public virtual object Clone()
        {
            return MemberwiseClone() as PropertyValidationRule;
        }

        #endregion
    }
}