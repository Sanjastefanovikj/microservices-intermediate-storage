using MicroservicesIntermediateStorage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public interface IIntermediateStorageService
    {
        // Account operations
        Task<bool> SaveAccountAsync(Account account);
        Task<Account?> GetAccountAsync(int accountId);
        Task<IEnumerable<Account>> GetAllAccountsAsync();

        // Transaction operations
        Task<bool> SaveTransactionAsync(Transaction transaction);
        Task<Transaction?> GetTransactionAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetAllTransactionsAsync();

        // Notification operations
        Task<bool> SaveNotificationAsync(Notification notification);
        Task<Notification?> GetNotificationAsync(int notificationId);
        Task<IEnumerable<Notification>> GetAllNotificationsAsync();
    }
}
