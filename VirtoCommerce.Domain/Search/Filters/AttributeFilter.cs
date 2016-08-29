using System;
using System.Text;
using System.Xml.Serialization;

namespace VirtoCommerce.Domain.Search.Filters
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public partial class AttributeFilter
    {
        [XmlElement("display")]
        public FilterDisplayName[] DisplayNames { get; set; }

        public string CacheKey
        {
            get
            {
                var key = new StringBuilder();
                key.Append("_af:" + Key);
                foreach (var field in this.Values)
                {
                    key.Append("_af:" + field.Id);
                }
                return key.ToString();
            }
        }
    }
}
