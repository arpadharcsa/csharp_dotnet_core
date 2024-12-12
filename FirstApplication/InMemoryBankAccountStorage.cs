namespace FirstApplication;
public class InMemoryBankAccountStorage : BankAccountStorage
{
    private readonly List<BankAccount> _accounts = new();

    public void AddAccount(BankAccount account)
    {
        _accounts.Add(account);
    }

    public IEnumerable<BankAccount> GetAllAccounts()
    {
        return _accounts;
    }

    public BankAccount GetAccountById(Guid id)
    {
        return _accounts.FirstOrDefault(a => a.Id == id);
    }

    public void UpdateAccount(BankAccount account)
    {
        var existingAccount = GetAccountById(account.Id);
        if (existingAccount != null)
        {
            existingAccount.Name = account.Name;
            existingAccount.Balance = account.Balance;
        }
    }

    public void DeleteAccount(Guid id)
    {
        var account = GetAccountById(id);
        if (account != null)
        {
            _accounts.Remove(account);
        }
    }
}