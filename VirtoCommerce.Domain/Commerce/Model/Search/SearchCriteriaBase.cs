using System.Collections.Generic;
using System.Linq;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Commerce.Model.Search
{
    public abstract class SearchCriteriaBase
    {
        public string ResponseGroup { get; set; }

        /// <summary>
        /// Search object type (CustomerOrder, Subscription etc)
        /// </summary>
        public virtual string ObjectType { get; set; }

        private string[] _objectTypes;
        public virtual string[] ObjectTypes
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

        public IList<string> ObjectIds { get; set; }

        public string SearchPhrase { get; set; }

        /// <summary>
        /// Search phrase language 
        /// </summary>
        public string LanguageCode { get; set; }


        /// <summary>
        /// Sorting expression property1:asc;property2:desc
        /// </summary>
        public string Sort { get; set; }

        public virtual SortInfo[] SortInfos => SortInfo.Parse(Sort).ToArray();


        public int Skip { get; set; }
        public int Take { get; set; } = 20;
    }
}
