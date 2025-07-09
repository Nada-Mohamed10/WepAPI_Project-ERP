using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.SubAccount;
using Project_ERP.Services.SubAccountServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountController : ControllerBase
    {
        ISubAccountService SubAccountService;
        public SubAccountController(ISubAccountService subAccountService)
        {
            this.SubAccountService = subAccountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subAccounts = await SubAccountService.GetAllAsync();
            return Ok(subAccounts);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subAccount = await SubAccountService.GetByIdAsync(id);
            if (subAccount == null)
            {
                return NotFound();
            }
            return Ok(subAccount);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubAccountDto subAccountDto)
        {
            if (subAccountDto == null)
            {
                return BadRequest("Invalid sub-account data.");
            }
            var subAccount = await SubAccountService.AddAsync(subAccountDto);
            return CreatedAtAction(nameof(GetById), new { id = subAccount.SubAccountID }, subAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSubAccountDto subAccountDto)
        {
            if (subAccountDto == null)
            {
                return BadRequest("Invalid sub-account data.");
            }
            var updatedSubAccount = await SubAccountService.UpdateAsync(id, subAccountDto);
            if (updatedSubAccount == null)
            {
                return NotFound($"Sub-account with ID {id} not found.");
            }
            return Ok(updatedSubAccount);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await SubAccountService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Sub-account with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
