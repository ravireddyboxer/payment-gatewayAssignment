using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.BLL.Models
{
    public class PaymentRequest
    {
        [Required]
        public string CheckOutId { get; set; } = null!; // Reference id from the merchant to map the transaction

        public Merchant Merchant { get; set; } = null!;
        public CardDetails CardDetails { get; set; } = null!;

        [Required]
        public string CurrencyCode { get; set; } = null!;

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsCardToBeSaved { get; set; } // To save credit/debit card details

    }
}
