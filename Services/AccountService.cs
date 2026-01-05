using MicroservicesIntermediateStorage.Models;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public class AccountService : IAccountService
    {
        private readonly IIntermediateStorageService _intermediateStorage;

        public AccountService(IIntermediateStorageService intermediateStorage)
        {
            _intermediateStorage = intermediateStorage;
        }

        public async Task<bool> CreateAccountAsync(Account account)
        {
            return await _intermediateStorage.SaveAccountAsync(account);
        }

        public async Task<Account?> GetAccountAsync(int accountId)
        {
            return await _intermediateStorage.GetAccountAsync(accountId);
        }

        public async Task<bool> UpdateAccountBalanceAsync(int accountId, decimal amount)
        {
            var account = await _intermediateStorage.GetAccountAsync(accountId);
            if (account == null)
                return false;

            account.Balance += amount;
            return await _intermediateStorage.SaveAccountAsync(account);
        }
    }
}
