using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.SubAccountType;
using Project_ERP.Services.SubAccountTypeServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountTypeController : ControllerBase
    {
        ISubAccountTypeService subAccountTypeService;
        public SubAccountTypeController(ISubAccountTypeService subAccountTypeService)
        {
            this.subAccountTypeService = subAccountTypeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subAccountTypes = await subAccountTypeService.GetAllAsync();
            return Ok(subAccountTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subAccountType = await subAccountTypeService.GetByIdAsync(id);
            if (subAccountType == null)
            {
                return NotFound();
            }
            return Ok(subAccountType);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubAccountTypeDto subAccountTypeDto)
        {
            if (subAccountTypeDto == null)
            {
                return BadRequest("Invalid sub-account type data.");
            }
            var subAccountType = await subAccountTypeService.AddAsync(subAccountTypeDto);
            return CreatedAtAction(nameof(GetById), new { id = subAccountType.SubAccountTypeID }, subAccountType);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateSubAccountTypeDto subAccountTypeDto)
        {
            if (subAccountTypeDto == null)
            {
                return BadRequest("Invalid sub-account type data.");
            }
            var updatedSubAccountType = await subAccountTypeService.UpdateAsync(id, subAccountTypeDto);
            if (updatedSubAccountType == null)
            {
                return NotFound($"Sub-account type with ID {id} not found.");
            }
            return Ok(updatedSubAccountType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await subAccountTypeService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Sub-account type with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
