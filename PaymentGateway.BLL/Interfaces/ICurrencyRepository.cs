using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Interfaces
{
    public interface ICurrencyRepository
    {
        public Task<bool> IsValidCurrency(string currencyCode);
    }
}
