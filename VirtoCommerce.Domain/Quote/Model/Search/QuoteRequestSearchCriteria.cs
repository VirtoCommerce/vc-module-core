using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Quote.Model
{
	public class QuoteRequestSearchCriteria : SearchCriteriaBase
    {
	    public string Number { get; set; }
		public string Keyword { get; set; }
		public string CustomerId { get; set; }
		public string StoreId { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Tag { get; set; } 	
	}
}
