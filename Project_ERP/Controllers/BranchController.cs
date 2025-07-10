using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.Branch;
using Project_ERP.Models;
using Project_ERP.Responses;
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
            if (branch == null || !branch.Any())
                return NotFound();
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

        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var branch = await branchService.GetByNameAsync(name);
            if (branch == null)
            {
                return NotFound($"Branch with name {name} not found.");
            }
            return Ok(branch);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBranchDto createBranchDto)
        {
            var account = await branchService.AddAsync(createBranchDto);
            if (account == null)
            {
                return BadRequest(new ApiResponse<string>(new List<string> { "Invalid branch data." }));
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
