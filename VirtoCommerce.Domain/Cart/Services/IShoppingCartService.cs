using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Cart.Model;

namespace VirtoCommerce.Domain.Cart.Services
{
	public interface IShoppingCartService
	{
		ShoppingCart[] GetByIds(string[] cartIds, string responseGroup = null);
		void SaveChanges(ShoppingCart[] carts);
		void Delete(string[] cartIds);
	}
}
