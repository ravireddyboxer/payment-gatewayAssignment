using AutoWrapper;
using Microsoft.EntityFrameworkCore;
using PaymentGateway.API;
using PaymentGateway.BLL.Interfaces;
using PaymentGateway.BLL.Services;
using PaymentGateway.DAL;
using PaymentGateway.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom service injection
builder.Services.AddDbContext<DatabaseContext>(options=>options.UseInMemoryDatabase("PaymentDb"));
builder.Services.AddTransient<IPaymentProcessor, PaymentProcessor>();
builder.Services.AddTransient<ITransactionRepository, TransactionRepository>();
builder.Services.AddTransient<IMerchantRepository, MerchantRepository>();
builder.Services.AddTransient<IBankService, CKOBankService>();
builder.Services.AddTransient<ICardValidator, CardValidator>();
builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();


var app = builder.Build();
SeedData.AddSeedData(app);
app.UseApiResponseAndExceptionWrapper();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
