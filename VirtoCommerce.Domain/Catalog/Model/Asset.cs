using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class Asset : AuditableEntity, ISeoSupport, ILanguageSupport, IInheritable, ICloneable
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Group { get; set; }
        public string MimeType { get; set; }
        public long Size { get; set; }
        public byte[] BinaryData { get; set; }


        #region ISeoSupport Members
        public string SeoObjectType { get { return GetType().Name; } }
        public ICollection<SeoInfo> SeoInfos { get; set; }
        #endregion

        #region ILanguageSupport Members
        public string LanguageCode { get; set; }
        #endregion

        #region IInheritable Members
        public bool IsInherited { get; set; }
        #endregion

        #region ICloneable members

        public virtual object Clone()
        {
            var result = MemberwiseClone() as Asset;

            result.SeoInfos = SeoInfos?.Select(x => x.Clone() as SeoInfo).ToList() ?? result.SeoInfos;

            return result;
        }

        #endregion
    }
}
