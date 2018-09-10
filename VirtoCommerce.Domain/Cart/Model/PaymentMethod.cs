using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Model
{
    public class PaymentMethod : ValueObject
    {
        public string GatewayCode { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}
