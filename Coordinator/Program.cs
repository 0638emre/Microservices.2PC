using Coordinator.Models.Context;
using Coordinator.Services;
using Coordinator.Services.Abstraction;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TwoPhaseCommitContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

builder.Services.AddHttpClient("OrderAPI", client => client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("OrderAPI")));
builder.Services.AddHttpClient("StockAPI", client => client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("StockAPI")));
builder.Services.AddHttpClient("PaymentAPI", client => client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("PaymentAPI")));


builder.Services.AddTransient<ITransactionService, TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/create-order-transaction", async (ITransactionService transactionService) =>
{
    //phase 1 - prepare
    var transactionId = await transactionService.CreateTransaction();
    await transactionService.PrepareServices(transactionId);
    bool transactionState = await transactionService.CheckTransactionStateServices(transactionId);

    if (transactionState)
    {
        //phase 2 - commit
        await transactionService.Commit(transactionId);
        transactionState = await transactionService.CheckTransactionStateServices(transactionId);    
    }

    if (!transactionState)
    {
        await transactionService.Rollback(transactionId);
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();