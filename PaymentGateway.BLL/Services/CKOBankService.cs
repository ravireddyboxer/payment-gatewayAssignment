using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Services
{
    // Simulating bank service. Only test code
    public class CKOBankService : IBankService
    {
        public string TransferMoneyFromCardToBankAccount(CardDetails cardDetails, MerchantDetails merchantBank, decimal amount)
        {
            Guid transactionId= Guid.NewGuid();
            // Bank do the transaction // simply returning the transaction id
            return transactionId.ToString();
        }
    }
}
