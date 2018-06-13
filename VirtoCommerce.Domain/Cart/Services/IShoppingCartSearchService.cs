using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Cart.Model;
using VirtoCommerce.Domain.Commerce.Model.Search;

namespace VirtoCommerce.Domain.Cart.Services
{
	public interface IShoppingCartSearchService
	{
		GenericSearchResult<ShoppingCart> Search(ShoppingCartSearchCriteria criteria);
	}
}
