using Microsoft.EntityFrameworkCore;
using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DatabaseContext _context;

        public TransactionRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Transaction> GetPaymentDetails(Guid transactionId)
        {
            return await _context.Transactions.Where(x => x.Id == transactionId).FirstOrDefaultAsync();
        }

        public async Task SaveTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
           await _context.SaveChangesAsync();
        }
    }
}
