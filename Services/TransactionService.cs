using MicroservicesIntermediateStorage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IIntermediateStorageService _intermediateStorage;

        public TransactionService(IIntermediateStorageService intermediateStorage)
        {
            _intermediateStorage = intermediateStorage;
        }

        public async Task<bool> CreateTransactionAsync(Transaction transaction)
        {
            // Save transaction
            var result = await _intermediateStorage.SaveTransactionAsync(transaction);

            // Update account balances
            var fromAccount = await _intermediateStorage.GetAccountAsync(transaction.FromAccountId);
            var toAccount = await _intermediateStorage.GetAccountAsync(transaction.ToAccountId);

            if (fromAccount == null || toAccount == null)
                return false;

            fromAccount.Balance -= transaction.Amount;
            toAccount.Balance += transaction.Amount;

            await _intermediateStorage.SaveAccountAsync(fromAccount);
            await _intermediateStorage.SaveAccountAsync(toAccount);

            return result;
        }

        public async Task<Transaction?> GetTransactionAsync(int transactionId)
        {
            return await _intermediateStorage.GetTransactionAsync(transactionId);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int accountId)
        {
            var allTransactions = await _intermediateStorage.GetAllTransactionsAsync();
            return allTransactions.Where(t => t.FromAccountId == accountId || t.ToAccountId == accountId);
        }
    }
}
