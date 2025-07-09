using Project_ERP.DTOs.JV;

namespace Project_ERP.Services.JVs
{
    public interface IJVService
    {
        Task<IEnumerable<ReadJVDto>> GetAllAsync();
        Task<ReadJVDto> GetByIdAsync(int id);
        Task<ReadJVDto> AddAsync(CreateJVDto jvDto);
        Task<ReadJVDto> UpdateAsync(int id, UpdateJVDto jvDto);
        Task<bool> DeleteAsync(int id);
    }
}
