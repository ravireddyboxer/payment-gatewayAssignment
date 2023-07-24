using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Models;

namespace PaymentGateway.DAL.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly DatabaseContext _dbContext;

        public MerchantRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public MerchantDetails GetMerchantBankAccount(int merchantId)
        {
            return _dbContext.MerchantBankAccounts.FirstOrDefault(x => x.MerchantId == merchantId);
        }

        public bool IsValidMerchant(int merchantId)
        {
            bool IsMerchantExist = _dbContext.Merchants.Any(x => x.MerchantId == merchantId);
            return IsMerchantExist;
        }
    }
}
