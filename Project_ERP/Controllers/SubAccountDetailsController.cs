using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.SubAccounts_Details;
using Project_ERP.Services.SubAccountDetailsServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAccountDetailsController : ControllerBase
    {
        ISubAccountDetailsService subAccountDetailsService;
        public SubAccountDetailsController(ISubAccountDetailsService subAccountDetailsService)
        {
            this.subAccountDetailsService = subAccountDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subAccountDetails = await subAccountDetailsService.GetAllAsync();
            return Ok(subAccountDetails);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subAccountDetail = await subAccountDetailsService.GetByIdAsync(id);
            if (subAccountDetail == null)
            {
                return NotFound();
            }
            return Ok(subAccountDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSubAccounts_DetailsDto subAccountDetailsDto)
        {
            if (subAccountDetailsDto == null)
            {
                return BadRequest("Invalid sub-account details data.");
            }
            var subAccountDetail = await subAccountDetailsService.AddAsync(subAccountDetailsDto);
            return CreatedAtAction(nameof(GetById), new { id = subAccountDetail.SubAccountDetailID }, subAccountDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSubAccounts_DetailsDto updateSubAccountsDetailsDto)
        {
            var updatedSubAccountDetail = await subAccountDetailsService.UpdateAsync(id, updateSubAccountsDetailsDto);

            if (updatedSubAccountDetail == null)
            {
                return NotFound($"Sub-account details with ID {id} not found.");
            }

            return Ok(updatedSubAccountDetail);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await subAccountDetailsService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Sub-account details with ID {id} not found.");
            }
            return NoContent();


        }
    }
}
