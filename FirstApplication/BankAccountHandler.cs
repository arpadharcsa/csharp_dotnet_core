namespace FirstApplication;

public static class BankAccountHandler
{
    public static void MapBankAccountEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapPost("/accounts", (BankAccountStorage storage, BankAccount account) =>
        {
            account.Id = Guid.NewGuid();
            storage.AddAccount(account);
            return Results.Created($"/accounts/{account.Id}", account);
        });

        routes.MapGet("/accounts", (BankAccountStorage storage) => Results.Ok(storage.GetAllAccounts()));

        routes.MapGet("/accounts/{id}", (BankAccountStorage storage, Guid id) =>
        {
            var account = storage.GetAccountById(id);
            return account is not null ? Results.Ok(account) : Results.NotFound();
        });

        routes.MapPut("/accounts/{id}", (BankAccountStorage storage, Guid id, BankAccount updatedAccount) =>
        {
            var account = storage.GetAccountById(id);
            if (account is null)
            {
                return Results.NotFound();
            }

            account.Name = updatedAccount.Name;
            account.Balance = updatedAccount.Balance;
            storage.UpdateAccount(account);
            return Results.NoContent();
        });

        routes.MapDelete("/accounts/{id}", (BankAccountStorage storage, Guid id) =>
        {
            var account = storage.GetAccountById(id);
            if (account is null)
            {
                return Results.NotFound();
            }

            storage.DeleteAccount(id);
            return Results.NoContent();
        });

    }
}