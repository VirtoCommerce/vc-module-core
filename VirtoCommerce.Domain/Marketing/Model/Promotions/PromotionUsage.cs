using System;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Marketing.Model
{
	public class PromotionUsage : AuditableEntity
	{
        //The identifier of the object for which it was used
        public string ObjectId { get; set; }
        public string ObjectType { get; set; }

        public string CouponCode { get; set; }
        public string PromotionId { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

	}
}
