using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Order.Model
{
	public class CustomerOrderSearchCriteria : SearchCriteriaBase
    {		     

        public string Keyword { get; set; }

        /// <summary>
        /// Search by numbers
        /// </summary>
        public string Number { get; set; }

        private string[] _numbers;
        public string[] Numbers
        {
            get
            {
                if (_numbers == null && !string.IsNullOrEmpty(Number))
                {
                    _numbers = new[] { Number };
                }
                return _numbers;
            }
            set
            {
                _numbers = value;
            }
        }

        /// <summary>
        /// Search by status
        /// </summary>
        public string Status { get; set; }

        private string[] _statuses;
        public string[] Statuses
        {
            get
            {
                if (_statuses == null && !string.IsNullOrEmpty(Status))
                {
                    _statuses = new[] { Status };
                }
                return _statuses;
            }
            set
            {
                _statuses = value;
            }
        }


        /// <summary>
        /// It used to limit search within an operation (customer order for example)
        /// </summary>
        public string OperationId { get; set; }

        public string CustomerId { get; set; }
        public string EmployeeId { get; set; }
        public string[] StoreIds { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }       

    }
}
