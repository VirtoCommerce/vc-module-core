using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Commerce.Model.Search
{
    public class GenericSearchResult<T>
    {
        public int TotalCount { get; set; }
        public List<T> Results { get; set; }
    }
}
