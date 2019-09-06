using System;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Catalog.Model
{
    public class EditorialReview : AuditableEntity, ILanguageSupport, ICloneable, IInheritable
    {
        public string Content { get; set; }
        public string ReviewType { get; set; }

        #region ILanguageSupport Members
        public string LanguageCode { get; set; }
        #endregion

        #region IInheritable Members
        public bool IsInherited { get; set; }
        #endregion

        #region ICloneable members
        public virtual object Clone()
        {
            return MemberwiseClone() as EditorialReview;
        }
        #endregion
    }
}
