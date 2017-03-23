namespace VirtoCommerce.Domain.Marketing.Model.Promotions
{
    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; }

        public string PromotionId { get; set; }

        public string MemberId { get; set; }

        public string OrderId { get; set; }

        public string OrderNumber { get; set; }
    }
}