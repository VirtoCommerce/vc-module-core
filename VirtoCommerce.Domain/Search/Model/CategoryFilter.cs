using System;
using System.Text;

namespace VirtoCommerce.Domain.Search.Model
{
    [Obsolete("Moved to search module and will be removed in the next release")]
    public class CategoryFilter : ISearchFilter
    {
        public string Key { get; set; }

        public CategoryFilterValue[] Values
        {
            get;set;
        }

        public string CacheKey
        {
            get
            {
                var key = new StringBuilder();
                key.Append("_cf:" + Key);
                foreach (var field in this.Values)
                {
                    key.Append("_cf:" + field.Id);
                }
                return key.ToString();
            }
        }
    }
}
