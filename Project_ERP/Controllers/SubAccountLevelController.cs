using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.SubAccounts_Levels;
using Project_ERP.Services.SubAccountLevelServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountLevelController : ControllerBase
    {
        ISubAccountLevelService subAccountLevelService;
        public SubAccountLevelController(ISubAccountLevelService subAccountLevelService)
        {
            this.subAccountLevelService = subAccountLevelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subAccountLevels = await subAccountLevelService.GetAllAsync();
            return Ok(subAccountLevels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subAccountLevel = await subAccountLevelService.GetByIdAsync(id);
            if (subAccountLevel == null)
            {
                return NotFound();
            }
            return Ok(subAccountLevel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubAccounts_LevelsDto subAccountLevelDto)
        {
            if (subAccountLevelDto == null)
            {
                return BadRequest("Invalid sub-account level data.");
            }
            var subAccountLevel = await subAccountLevelService.AddAsync(subAccountLevelDto);
            return CreatedAtAction(nameof(GetById), new { id = subAccountLevel.LevelID }, subAccountLevel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSubAccounts_LevelsDto subAccountLevelDto)
        {
            if (subAccountLevelDto == null)
            {
                return BadRequest("Invalid sub-account level data.");
            }
            var updatedSubAccountLevel = await subAccountLevelService.UpdateAsync(id, subAccountLevelDto);
            if (updatedSubAccountLevel == null)
            {
                return NotFound($"Sub-account level with ID {id} not found.");
            }
            return Ok(updatedSubAccountLevel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await subAccountLevelService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Sub-account level with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
