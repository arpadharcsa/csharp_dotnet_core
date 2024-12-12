using FirstApplication;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<BankAccountStorage, InMemoryBankAccountStorage>();
var app = builder.Build();
app.MapBankAccountEndpoints();
app.Run();