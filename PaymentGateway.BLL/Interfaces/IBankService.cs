using PaymentGateway.BLL.Models;

namespace PaymentGateway.BLL.Interfaces
{
    public interface IBankService
    {
        public string TransferMoneyFromCardToBankAccount(CardDetails cardDetails, MerchantDetails merchantBank, decimal amount);
    }
}
