using System;
using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Catalog.Model
{
    public class Catalog : Entity, IHasProperties, ICloneable
    {
        public string Name { get; set; }
        public bool IsVirtual { get; set; }
        public CatalogLanguage DefaultLanguage
        {
            get
            {
                CatalogLanguage retVal = null;
                if (Languages != null)
                {
                    retVal = Languages.FirstOrDefault(x => x.IsDefault);
                }
                return retVal;
            }
        }
        public ICollection<CatalogLanguage> Languages { get; set; }

        #region IHasProperties members
        public ICollection<Property> Properties { get; set; }
        public ICollection<PropertyValue> PropertyValues { get; set; }
        #endregion

        #region ICloneable members
        public virtual object Clone()
        {
            var result = MemberwiseClone() as Catalog;

            result.Properties = Properties?.Select(x => x.Clone() as Property).ToList() ?? result.Properties;
            result.PropertyValues = PropertyValues?.Select(x => x.Clone() as PropertyValue).ToList() ?? result.PropertyValues;
            result.Languages = Languages?.Select(x => x.Clone() as CatalogLanguage).ToList() ?? result.Languages;

            return result;
        }
        #endregion
    }
}
