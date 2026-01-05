using MicroservicesIntermediateStorage.Models;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public interface IAccountService
    {
        Task<bool> CreateAccountAsync(Account account);
        Task<Account?> GetAccountAsync(int accountId);
        Task<bool> UpdateAccountBalanceAsync(int accountId, decimal amount);
    }
}
