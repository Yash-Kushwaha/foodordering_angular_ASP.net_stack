using System;

namespace OrderFood_web_API.Models
{
    public class PromotionCode
    {
        public string PromotionId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Discount { get; set; }
        public int UseCount { get; set; }
    }
}
