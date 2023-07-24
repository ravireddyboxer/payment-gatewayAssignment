using Microsoft.EntityFrameworkCore;
using PaymentGateway.BLL.Interfaces;

namespace PaymentGateway.DAL.Repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly DatabaseContext _context;

        public CurrencyRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async  Task<bool> IsValidCurrency(string currencyCode)
        {
            var code = await _context.Currencies.FirstOrDefaultAsync(x => x.Code == currencyCode);
            if (code == null)
                return false;
            return true;
            
        }
    }
}
