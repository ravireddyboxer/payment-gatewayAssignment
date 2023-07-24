using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.BLL.Models
{
    public class ShopperDetails
    {
        [Required]
        public string Id { get; set; } = null!; // Unique id given by the merchant to the shopper
        [Required]
        public string ShopperName { get; set; } = null!; // Name of the shopper who registered on the merchant website
        [Required]
        public string ShopperEmail { get; set; } = null!; // Email of the shopper who registered on the merchant website
    }
}
