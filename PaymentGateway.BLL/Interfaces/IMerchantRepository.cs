using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Interfaces
{
    public interface IMerchantRepository
    {
        public bool IsValidMerchant(int merchantId);
        public MerchantDetails GetMerchantBankAccount(int merchantId);
    }
}
