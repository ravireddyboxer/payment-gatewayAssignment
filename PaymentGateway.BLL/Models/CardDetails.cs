using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.BLL.Models
{
    public class CardDetails
    {
        
        [Required]
        [Key]
        public string CreditCardNumber { get; set; } = null!;
        [Required]
        public int ExpiryMonth { get; set; } 
        [Required]
        public int ExpiryYear { get; set; }
        [Required]
        public int CVV { get; set; }
        [Required]
        public string NameOnTheCard { get; set; } = null!;
        [Required]
        public ShopperDetails ShopperDetails { get; set; }=null!;
    }
}
