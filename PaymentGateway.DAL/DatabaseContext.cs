using Microsoft.EntityFrameworkCore;
using PaymentGateway.BLL.Models;
using System.Data;

namespace PaymentGateway.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<MerchantDetails> Merchants { get; set; } = null!;
        public DbSet<CardDetails> CardDetails { get; set; } = null!;
        public DbSet<MerchantDetails> MerchantBankAccounts { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; }


    }
}
