using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.Account;
using Project_ERP.Models;
using Project_ERP.Services.AccountServices;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
           this.accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var account = await accountService.GetAllAsync();
            return Ok(account);
          
        }

        [HttpGet("ByID")]
        public  async Task<IActionResult> Get(int id)
        {
           var account= await accountService.GetByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var account = await accountService.GetByNameAsync(name);
            if (account == null)
            {
                return NotFound($"Account with name {name} not found.");
            }
            return Ok(account);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAccountDto accountDto)
        {
           var account =  await accountService.AddAsync(accountDto);
            if (account == null)
            {
                return BadRequest("Invalid account data.");
            }
            return CreatedAtAction(nameof(Get), new { id = account.AccountID }, account);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAccountDto accountDto)
        {
            var account=  await accountService.UpdateAsync(id, accountDto);
            if (account == null)
            {
                return NotFound($"Account with ID {id} not found.");
            }
            return Ok(account);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var account = accountService.DeleteAsync(id);
            if (!account.Result)
            {
                return NotFound($"Account with ID {id} not found.");
            }
            return NoContent();
        }


    }
}
