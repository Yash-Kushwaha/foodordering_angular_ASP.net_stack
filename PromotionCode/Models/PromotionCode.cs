using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PromotionCode.Models
{
    public class PromotionCode
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required]
        public string PromotionId { get; set; } = DateTime.Now.Ticks.ToString("x");
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public int Discount { get; set; }
        [Required]
        public int UseCount { get; set; }
    }
}
