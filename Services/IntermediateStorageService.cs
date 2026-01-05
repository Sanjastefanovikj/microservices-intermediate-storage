using MicroservicesIntermediateStorage.Models;
using MicroservicesIntermediateStorage.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public class IntermediateStorageService : IIntermediateStorageService
    {
        private readonly BankingDbContext _dbContext;

        public IntermediateStorageService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Account methods
        public async Task<bool> SaveAccountAsync(Account account)
        {
            var existingAccount = await _dbContext.Accounts.FindAsync(account.AccountId);
            if (existingAccount == null)
            {
                await _dbContext.Accounts.AddAsync(account);
            }
            else
            {
                existingAccount.OwnerName = account.OwnerName;
                existingAccount.Balance = account.Balance;
                existingAccount.LastUpdated = System.DateTime.UtcNow;
                _dbContext.Accounts.Update(existingAccount);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Account?> GetAccountAsync(int accountId)
        {
            return await _dbContext.Accounts.FindAsync(accountId);
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        // Transaction methods
        public async Task<bool> SaveTransactionAsync(Transaction transaction)
        {
            transaction.Timestamp = System.DateTime.UtcNow;
            var existingTransaction = await _dbContext.Transactions.FindAsync(transaction.TransactionId);
            if (existingTransaction == null)
            {
                await _dbContext.Transactions.AddAsync(transaction);
            }
            else
            {
                existingTransaction.FromAccountId = transaction.FromAccountId;
                existingTransaction.ToAccountId = transaction.ToAccountId;
                existingTransaction.Amount = transaction.Amount;
                existingTransaction.Timestamp = transaction.Timestamp;
                _dbContext.Transactions.Update(existingTransaction);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Transaction?> GetTransactionAsync(int transactionId)
        {
            return await _dbContext.Transactions.FindAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            return await _dbContext.Transactions.ToListAsync();
        }

        // Notification methods
        public async Task<bool> SaveNotificationAsync(Notification notification)
        {
            notification.SentAt = System.DateTime.UtcNow;
            var existingNotification = await _dbContext.Notifications.FindAsync(notification.NotificationId);
            if (existingNotification == null)
            {
                await _dbContext.Notifications.AddAsync(notification);
            }
            else
            {
                existingNotification.AccountId = notification.AccountId;
                existingNotification.Message = notification.Message;
                existingNotification.SentAt = notification.SentAt;
                _dbContext.Notifications.Update(existingNotification);
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Notification?> GetNotificationAsync(int notificationId)
        {
            return await _dbContext.Notifications.FindAsync(notificationId);
        }

        public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
        {
            return await _dbContext.Notifications.ToListAsync();
        }
    }
}
