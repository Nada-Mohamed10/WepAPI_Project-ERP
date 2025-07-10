using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_ERP.DTOs.City;
using Project_ERP.Services.CityServices;

namespace Project_ERP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await cityService.GetAllAsync();
            if (cities == null)
            {
                return NotFound("No cities found.");
            }
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var city = await cityService.GetByIdAsync(id);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);
        }

        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var city = await cityService.GetByNameAsync(name);
            if (city == null)
            {
                return NotFound($"City with name {name} not found.");
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCityDto createCityDto)
        {
            var city = await cityService.AddAsync(createCityDto);
            if (city == null)
            {
                return BadRequest("Invalid city data.");
            }
            return CreatedAtAction(nameof(GetById), new { id = city.CityID }, city);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCityDto updateCityDto)
        {
            var city = await cityService.UpdateAsync(id, updateCityDto);
            if (city == null)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return Ok(city);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await cityService.DeleteAsync(id);
            if (!result)
            {
                return NotFound($"City with ID {id} not found.");
            }
            return NoContent();
        }
    }
}
