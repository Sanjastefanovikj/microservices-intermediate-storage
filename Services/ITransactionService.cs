using MicroservicesIntermediateStorage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Services
{
    public interface ITransactionService
    {
        Task<bool> CreateTransactionAsync(Transaction transaction);
        Task<Transaction?> GetTransactionAsync(int transactionId);
        Task<IEnumerable<Transaction>> GetTransactionsForAccountAsync(int accountId);
    }
}
