using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Models
{
    public class MerchantDetails
    {
        [Key]
        public int MerchantId { get; set; }
        public string MerchantName { get; set; } = null!;
        public string MerchantBankAccountNumber { get; set; } =null!;
        public string MerchantBankCode { get; set; } = null!;
        public string MerchantBankSwiftCode { get; set; } = null!;
    }
}
