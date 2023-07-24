using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;

namespace PaymentGateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ILogger<PaymentsController> _logger;
        private readonly IPaymentProcessor _paymentProcessor;
        private readonly ITransactionRepository _transactionRepository;
        public PaymentsController(ILogger<PaymentsController> logger, IPaymentProcessor paymentProcessor, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _paymentProcessor = paymentProcessor;
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        [Route("ProcessPayment")]
        public async Task<ActionResult<PaymentResponse>> ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            return await _paymentProcessor.ProcessPayment(paymentRequest);
        }

        [HttpGet]
        [Route("GetPaymentDetails")]
        public async Task<ActionResult<Transaction>> GetPaymentDetails(string transactionId)
        {
            return await _transactionRepository.GetPaymentDetails(Guid.Parse(transactionId));
        }
    }
}
