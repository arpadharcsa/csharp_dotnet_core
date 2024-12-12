namespace FirstApplication;
public interface BankAccountStorage
{
    void AddAccount(BankAccount account);
    IEnumerable<BankAccount> GetAllAccounts();
    BankAccount GetAccountById(Guid id);
    void UpdateAccount(BankAccount account);
    void DeleteAccount(Guid id);
}