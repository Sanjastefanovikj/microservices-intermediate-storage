using Microsoft.AspNetCore.Mvc;
using MicroservicesIntermediateStorage.Models;
using MicroservicesIntermediateStorage.Services;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
        {
            var result = await _transactionService.CreateTransactionAsync(transaction);
            if (result)
                return Ok(new { message = "Transaction created successfully" });
            return BadRequest(new { message = "Failed to create transaction" });
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction(int transactionId)
        {
            var transaction = await _transactionService.GetTransactionAsync(transactionId);
            if (transaction == null)
                return NotFound();
            return Ok(transaction);
        }

        [HttpGet("account/{accountId}")]
        public async Task<IActionResult> GetTransactionsForAccount(int accountId)
        {
            var transactions = await _transactionService.GetTransactionsForAccountAsync(accountId);
            return Ok(transactions);
        }
    }
}
