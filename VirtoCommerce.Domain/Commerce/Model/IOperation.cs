using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;


namespace VirtoCommerce.Domain.Commerce.Model
{
	public interface IOperation : IEntity
	{
		string Number { get; set; }
		bool IsApproved { get; set; }
		string Status { get; set; }

		string Comment { get; set; }
		string Currency { get; set; }
		bool TaxIncluded { get; set; }
		decimal Sum { get; set; }
		decimal Tax { get; set; }
        IEnumerable<IOperation> ChildrenOperations { get; set; }
	}
}
