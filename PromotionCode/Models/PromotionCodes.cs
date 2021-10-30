using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionCode.Models
{
    public class PromotionCodes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PromotionId { get; set; } = DateTime.Now.Ticks.ToString("x");
        public DateTime ExpiryDate { get; set; }
        public int Discount { get; set; }
        public int UseCount { get; set; }
    }
}
