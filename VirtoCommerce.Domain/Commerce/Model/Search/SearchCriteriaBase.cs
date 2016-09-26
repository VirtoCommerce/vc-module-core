using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Commerce.Model.Search
{
    public abstract class SearchCriteriaBase
    {
        public SearchCriteriaBase()
        {
            Take = 20;
        }

        public string ResponseGroup { get; set; }

        /// <summary>
        /// Search object type (CustomerOrder, Subscription etc)
        /// </summary>
        public string ObjectType { get; set; }

        private string[] _objectTypes;
        public string[] ObjectTypes
        {
            get
            {
                if (_objectTypes == null && !string.IsNullOrEmpty(ObjectType))
                {
                    _objectTypes = new[] { ObjectType };
                }
                return _objectTypes;
            }
            set
            {
                _objectTypes = value;
            }
        }
        /// <summary>
        /// Sorting expression property1:asc;property2:desc
        /// </summary>
        public string Sort { get; set; }

        public SortInfo[] SortInfos
        {
            get
            {
                return SortInfo.Parse(Sort).ToArray();
            }
        }


        public int Skip { get; set; }
        public int Take { get; set; }

    }
}
