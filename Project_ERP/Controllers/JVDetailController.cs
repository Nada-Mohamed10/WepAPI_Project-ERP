using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.JVDetails;
using Project_ERP.Services.JVDetailsServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JVDetailController : ControllerBase
    {
        IJVDetailsService JVDetailsService;
        public JVDetailController(IJVDetailsService jVDetailsService)
        {
            this.JVDetailsService = jVDetailsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jvDetails = await JVDetailsService.GetAllAsync();
            return Ok(jvDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jvDetail = await JVDetailsService.GetByIdAsync(id);
            if (jvDetail == null)
            {
                return NotFound();
            }
            return Ok(jvDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJVDetailsDto jvDetailDto)
        {
            if (jvDetailDto == null)
            {
                return BadRequest("Invalid JV detail data.");
            }
            var jvDetail = await JVDetailsService.AddAsync(jvDetailDto);
            return CreatedAtAction(nameof(GetById), new { id = jvDetail.JVDetailID }, jvDetail);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateJVDetailsDto jvDetailDto) 
        {
            var JVDetail = await JVDetailsService.UpdateAsync(id, jvDetailDto); 
            if (JVDetail == null)
            {
                return NotFound($"JV detail with ID {id} not found.");
            }
            return Ok(JVDetail);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await JVDetailsService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"JV detail with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
