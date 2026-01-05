using Microsoft.AspNetCore.Mvc;
using MicroservicesIntermediateStorage.Models;
using MicroservicesIntermediateStorage.Services;
using System.Threading.Tasks;

namespace MicroservicesIntermediateStorage.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] Account account)
        {
            var result = await _accountService.CreateAccountAsync(account);
            if (result)
                return Ok(new { message = "Account created successfully" });
            return BadRequest(new { message = "Failed to create account" });
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAccount(int accountId)
        {
            var account = await _accountService.GetAccountAsync(accountId);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost("{accountId}/update-balance")]
        public async Task<IActionResult> UpdateBalance(int accountId, [FromQuery] decimal amount)
        {
            var result = await _accountService.UpdateAccountBalanceAsync(accountId, amount);
            if (result)
                return Ok(new { message = "Account balance updated successfully" });
            return BadRequest(new { message = "Failed to update account balance" });
        }
    }
}
