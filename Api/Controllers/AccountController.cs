using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Blast.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAccounts() =>
        Ok(await _accountService.GetAllAccountsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAccountById(string id) =>
        Ok(await _accountService.GetAccountByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody] Account account) =>
        Ok(await _accountService.CreateAccountAsync(account));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAccount(string id, [FromBody] Account account) =>
        Ok(await _accountService.UpdateAccountAsync(id, account));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccount(string id)
    {
        await _accountService.DeleteAccountAsync(id);
        return NoContent();
    }

    [HttpGet("{accountId}/wills")]
    public async Task<IActionResult> GetAccountWills(string accountId) =>
        Ok(await _accountService.GetAccountWillsAsync(accountId));

    [HttpGet("{accountId}/wills/active")]
    public async Task<IActionResult> GetActiveWill(string accountId) =>
        Ok(await _accountService.GetActiveWillAsync(accountId));
}