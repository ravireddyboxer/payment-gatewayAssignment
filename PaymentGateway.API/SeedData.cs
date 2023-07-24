using PaymentGateway.BLL.Models;
using PaymentGateway.DAL;

namespace PaymentGateway.API
{
    public class SeedData
    {
        public static void AddSeedData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<DatabaseContext>();


            // Add initial merchant data
            var merchant1 = new MerchantDetails
            {
                MerchantId = 1,
                MerchantName = "Amazon",
                MerchantBankAccountNumber = "37458587890",
                MerchantBankCode= "Chase",
                MerchantBankSwiftCode="Ind"
            };
            var merchant2 = new MerchantDetails
            {
                MerchantId = 2,
                MerchantName = "eBay",
                MerchantBankAccountNumber = "1234585959",
                MerchantBankCode = "American Express",
                MerchantBankSwiftCode = "Ind"
            };
            var merchant3 = new MerchantDetails
            {
                MerchantId = 3,
                MerchantName = "BurgerKing",
                MerchantBankAccountNumber = "67898585959",
                MerchantBankCode = "JP Morgan",
                MerchantBankSwiftCode = "Ind"
            };
            var merchant4 = new MerchantDetails
            {
                MerchantId = 4,
                MerchantName = "KFC",
                MerchantBankAccountNumber = "45678585959",
                MerchantBankCode = "ICICI",
                MerchantBankSwiftCode = "Ind"
            };
            db.Merchants.Add(merchant1);
            db.Merchants.Add(merchant2);
            db.Merchants.Add(merchant3);
            db.Merchants.Add(merchant4);

            // Add allowed currencies
            var currency1 = new Currency
            {
                Id = 1,
                Code = "USD",
                Name = "US Dollar"
            };
            var currency2 = new Currency
            {
                Id = 2,
                Code = "GBP",
                Name = "Pound Sterling"
            };
            db.Currencies.Add(currency1);
            db.Currencies.Add(currency2);
            db.SaveChanges();
        }
    }
}
