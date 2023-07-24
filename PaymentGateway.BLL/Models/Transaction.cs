using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public string DebitedFrom { get; set; } = null!;
        public string CreditedTo { get; set; } = null!;
        public string CheckOutId { get; set; } = null!;
        public string BankTransactionId { get; set; } = null!;

        public decimal Amount { get; set; }
    }
}
