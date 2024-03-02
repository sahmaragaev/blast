using Domain.Entities;

namespace Service.Interfaces;

public interface IAccountService
{
    Task<List<Account>> GetAllAccountsAsync();
    Task<Account> GetAccountByIdAsync(string id);
    Task<Account> CreateAccountAsync(Account account);
    Task<Account> UpdateAccountAsync(string id, Account account);
    Task DeleteAccountAsync(string id);
    Task<List<Will>?> GetAccountWillsAsync(string accountId);
    Task<Will?> GetActiveWillAsync(string accountId);
}