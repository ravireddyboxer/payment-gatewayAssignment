namespace PaymentGateway.BLL.Models
{
    public class PaymentResponse
    {
        public string PaymentStatus { get; set; } = null!;
        public Guid TransactionId { get; set; } 
        public string Message { get; set; } = null!;
    }
}
