using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Services
{
    public class CardValidator : ICardValidator
    {
        public bool IsValidCard(CardDetails cardDetails)
        {
            if (!cardDetails.CreditCardNumber.All(char.IsDigit))
                throw new ArgumentException("Card number should contain only digits");
            if (cardDetails.CreditCardNumber.Length != 16)
                throw new ArgumentException("Card number should contain exactly 16 digits");
            if (cardDetails.CVV.ToString().Length != 3)
                throw new ArgumentException("CVV should contain exactly 3 digits");
            if (cardDetails.ExpiryYear < DateTime.Now.Year)
                throw new ArgumentException("Expiry year should be greater than the current year");
            if (cardDetails.ExpiryYear == DateTime.Now.Year && cardDetails.ExpiryMonth < DateTime.Now.Month)
                throw new ArgumentException("Expiry month should be greater than the current month");
            return true;
        }
    }
}
