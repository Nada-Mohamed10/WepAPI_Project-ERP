using Project_ERP.DTOs.JVDetails;

namespace Project_ERP.Services.JVDetailsServices
{
    public interface IJVDetailsService
    {
        Task<IEnumerable<ReadJVDetailsDto>> GetAllAsync();
        Task<ReadJVDetailsDto> GetByIdAsync(int id);
        Task<ReadJVDetailsDto> AddAsync(CreateJVDetailsDto jvDetailsDto);
        Task<ReadJVDetailsDto> UpdateAsync(int id, UpdateJVDetailsDto jvDetailsDto);
        Task<bool> DeleteAsync(int id);
        
    }
}
