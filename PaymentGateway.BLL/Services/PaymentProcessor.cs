using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.BLL.Services
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICardValidator _cardValidator;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IBankService _bankService;

        public PaymentProcessor(IMerchantRepository merchantRepository, ICurrencyRepository currencyRepository, ICardValidator cardValidator, IBankService bankService, ITransactionRepository transactionRepository)
        {
            _merchantRepository = merchantRepository;
            _currencyRepository = currencyRepository;
            _cardValidator = cardValidator;
            _bankService = bankService;
            _transactionRepository = transactionRepository;
        }

        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentModel)
        {
            if (!_merchantRepository.IsValidMerchant(paymentModel.Merchant.MerchantId))
                throw new ArgumentException("Pls send valid merchant id");
            if (!await _currencyRepository.IsValidCurrency(paymentModel.CurrencyCode))
                throw new ArgumentException("Pls send valid currency code");
            _cardValidator.IsValidCard(paymentModel.CardDetails);

            var merchantBankAccount = _merchantRepository.GetMerchantBankAccount(paymentModel.Merchant.MerchantId);
            var bankTransactionId = _bankService.TransferMoneyFromCardToBankAccount(paymentModel.CardDetails, merchantBankAccount, paymentModel.Amount);
            var transaction = new Transaction { Id = Guid.NewGuid(), BankTransactionId = bankTransactionId, CheckOutId = paymentModel.CheckOutId, CreditedTo = merchantBankAccount.MerchantBankAccountNumber, DebitedFrom = paymentModel.CardDetails.CreditCardNumber, Amount = paymentModel.Amount };
            await _transactionRepository.SaveTransaction(transaction);
            return  new PaymentResponse { Message ="Payment captured successfully", PaymentStatus ="Captured", TransactionId = transaction.Id};

        }


    }
}
