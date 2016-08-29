using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VirtoCommerce.Domain.Search.Filters
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class FilterDisplayName
    {
        [XmlAttribute("language")]
        public string Language { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}
