using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    /// <summary>
    /// Represent dictionary property values 
    /// </summary>
    [Obsolete("Replaced to PropertyDictionaryItem")]
    public class PropertyDictionaryValue : Entity, ICloneable
    {
        /// <summary>
        /// Property identifier
        /// </summary>
		public string PropertyId { get; set; }
        public Property Property { get; set; }
        /// <summary>
        /// Alias for value used for group same dict values in different languages
        /// </summary>
		public string Alias { get; set; }
        /// <summary>
        /// Language
        /// </summary>
		public string LanguageCode { get; set; }
        public string Value { get; set; }
        //The dictionary item identifier 
        public string ValueId { get; set; }

        #region ICloneable members
        public virtual object Clone()
        {
            return MemberwiseClone() as PropertyDictionaryValue;
        }
        #endregion
    }
}
