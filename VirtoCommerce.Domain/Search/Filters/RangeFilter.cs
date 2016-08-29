using System;
using System.Text;

namespace VirtoCommerce.Domain.Search.Filters
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public partial class RangeFilter
    {
        public string CacheKey
        {
            get
            {
                var key = new StringBuilder();
                key.Append("_rf:" + Key);
                foreach (var field in this.Values)
                {
                    key.Append("_rf:" + field.Id);
                }
                return key.ToString();
            }
        }
    }
}
