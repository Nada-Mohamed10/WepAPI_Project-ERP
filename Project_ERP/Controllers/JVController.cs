using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.JV;
using Project_ERP.Services.JVs;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JVController : ControllerBase
    {
        IJVService jvService;
        public JVController(IJVService jvService)
        {
            this.jvService = jvService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var jvs = await jvService.GetAllAsync();
            if (jvs == null || !jvs.Any())
            {
                return NotFound("No journal vouchers found.");
            }
            return Ok(jvs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jv = await jvService.GetByIdAsync(id);
            if (jv == null)
            {
                return NotFound($"Journal voucher with ID {id} not found.");
            }
            return Ok(jv);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJVDto createJVDto)
        {

            var jv = await jvService.AddAsync(createJVDto);
            if (jv == null)
            {
                return BadRequest("Failed to create journal voucher.");
            }
            return CreatedAtAction(nameof(GetById), new { id = jv.JVID }, jv);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateJVDto updateJVDto)
        {
            var updatedJV = await jvService.UpdateAsync(id, updateJVDto);
            if (updatedJV == null)
            {
                return NotFound($"Journal voucher with ID {id} not found.");
            }
            return Ok(updatedJV);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await jvService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"Journal voucher with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
