using System;
using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;
namespace VirtoCommerce.Domain.Marketing.Model
{
    public class Coupon : AuditableEntity
    {
        /// <summary>
        /// 0 infinitive
        /// </summary>
        public int MaxUsesNumber { get; set; }
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// coupon code
        /// </summary>
        public string Code { get; set; }        
        public string PromotionId { get; set; }
    }
}