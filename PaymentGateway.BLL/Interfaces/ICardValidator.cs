using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Interfaces
{
    public interface ICardValidator
    {
        public bool IsValidCard(CardDetails cardDetails);
    }
}
