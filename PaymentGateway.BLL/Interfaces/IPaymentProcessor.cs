using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Interfaces
{
    public interface IPaymentProcessor
    {
        public Task<PaymentResponse> ProcessPayment(PaymentRequest paymentModel);
    }
}
