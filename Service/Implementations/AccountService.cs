using Database.DbContexts;
using Domain.Entities;
using MongoDB.Driver;
using Service.Interfaces;

namespace Service.Implementations;

public class AccountService : IAccountService
{
    private readonly IMongoCollection<Account> _accounts;

    public AccountService(MongoDbContext dbContext)
    {
        _accounts = dbContext.Accounts;
    }

    public async Task<List<Account>> GetAllAccountsAsync() =>
        await _accounts.Find(account => true).ToListAsync();

    public async Task<Account> GetAccountByIdAsync(string id) =>
        await _accounts.Find<Account>(account => account.Id == id).FirstOrDefaultAsync();

    public async Task<Account> CreateAccountAsync(Account account)
    {
        await _accounts.InsertOneAsync(account);
        return account;
    }

    public async Task<Account> UpdateAccountAsync(string id, Account updatedAccount)
    {
        await _accounts.ReplaceOneAsync(account => account.Id == id, updatedAccount);
        return updatedAccount;
    }

    public async Task DeleteAccountAsync(string id) =>
        await _accounts.DeleteOneAsync(account => account.Id == id);

    public async Task<List<Will>?> GetAccountWillsAsync(string accountId)
    {
        var account = await GetAccountByIdAsync(accountId);
        return account?.Wills;
    }

    public async Task<Will?> GetActiveWillAsync(string accountId)
    {
        var account = await GetAccountByIdAsync(accountId);
        return account?.FinalWill;
    }
}