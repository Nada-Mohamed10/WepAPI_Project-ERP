using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.JVType;
using Project_ERP.Services.JVTypeServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JVTypeController : ControllerBase
    {
        IJVTypeService jvTypeService;
        public JVTypeController(IJVTypeService jvTypeService)
        {
            this.jvTypeService = jvTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jvTypes = await jvTypeService.GetAllAsync();
            if (jvTypes == null || !jvTypes.Any())
            {
                return NotFound("No JV Types found.");
            }
            return Ok(jvTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var jvType = await jvTypeService.GetByIdAsync(id);
            if (jvType == null)
            {
                return NotFound($"JV Type with ID {id} not found.");
            }
            return Ok(jvType);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateJVTypeDto createJVTypeDto)
        {
            var jvType = await jvTypeService.AddAsync(createJVTypeDto);
            if (jvType == null)
            {
                return BadRequest("Invalid JV Type data.");
            }
            return CreatedAtAction(nameof(GetById), new { id = jvType.JVTypeID }, jvType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateJVTypeDto updateJVTypeDto)
        {
            var updatedJVType = await jvTypeService.UpdateAsync(id, updateJVTypeDto);
            if (updatedJVType == null)
            {
                return NotFound($"JV Type with ID {id} not found.");
            }
            return Ok(updatedJVType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await jvTypeService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound($"JV Type with ID {id} not found.");
            }
            return NoContent();

        }
    }
}
