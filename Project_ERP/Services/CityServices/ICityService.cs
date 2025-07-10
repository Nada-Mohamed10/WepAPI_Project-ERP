using Project_ERP.DTOs.City;

namespace Project_ERP.Services.CityServices
{
    public interface ICityService
    {
        Task<IEnumerable<ReadCityDto>> GetAllAsync();
        Task<ReadCityDto> GetByIdAsync(int id);
        Task<ReadCityDto> GetByNameAsync(string name);
        Task<ReadCityDto> AddAsync(CreateCityDto cityDto);
        Task<ReadCityDto> UpdateAsync(int id, UpdateCityDto cityDto);
         Task<bool> DeleteAsync(int id);
    }
}
