using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.BLL.Models
{
    public class Merchant
    {
        [Required]
        public int MerchantId { get; set; }

        [Required]
        public string MerchantName { get; set; } = null!;

    }
}
