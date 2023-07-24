using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public CardRepository(DatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task SaveCardDetails(CardDetails cardDetails)
        {
            string encrytedCardNumber = EncryptCardNumber(cardDetails.CreditCardNumber);
            if (await _context.CardDetails.Where(x => x.CreditCardNumber == encrytedCardNumber).AnyAsync())
                return ;

            cardDetails.CreditCardNumber = encrytedCardNumber;
            _context.CardDetails.Add(cardDetails);
            _context.SaveChanges();
        }
        private string EncryptCardNumber(string cardNumber)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(cardNumber);
            TripleDESCryptoServiceProvider tripleDES = new()
            {
                Key = UTF8Encoding.UTF8.GetBytes(_configuration.GetSection("EncryptionDecryptKey").Value),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);


        }
    }
}
