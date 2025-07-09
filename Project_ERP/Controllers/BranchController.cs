using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.Branch;
using Project_ERP.Services.BranchServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        IBranchService branchService;
        public BranchController(IBranchService branchService)
        {
            this.branchService = branchService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branch = await branchService.GetAllAsync();
            if (branch == null) return NotFound("No branches found.");
            return Ok(branch);
        }



        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var brnach = await branchService.GetByIdAsync(id);
            if (brnach == null)
            {
                return NotFound();
            }
            return Ok(brnach);
        }



        [HttpPost]
        public async Task<IActionResult> Add(CreateBranchDto createBranchDto)
        {
            var account = await branchService.AddAsync(createBranchDto);
            if (account == null)
            {
                return BadRequest("Invalid branch data.");
            }
            return CreatedAtAction(nameof(GetById), new { id = account.BranchID }, account);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBranchDto updateBranchDto)
        {

            var updatedBranch = await branchService.UpdateAsync(id, updateBranchDto);
            if (updatedBranch == null) return NotFound($"Branch with ID {id} not found.");
            return Ok(updatedBranch);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var branch = await branchService.DeleteAsync(id);
            if (!branch)
            {
                return NotFound($"Branch with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
