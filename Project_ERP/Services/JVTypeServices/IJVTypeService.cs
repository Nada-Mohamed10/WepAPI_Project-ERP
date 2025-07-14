using Project_ERP.DTOs.JVType;

namespace Project_ERP.Services.JVTypeServices
{
    public interface IJVTypeService
    {
        Task<IEnumerable<ReadJVTypeDto>> GetAllAsync();
        Task<ReadJVTypeDto> GetByIdAsync(int id);
        Task<ReadJVTypeDto> GetByNameAsync(string name);
        Task<ReadJVTypeDto> AddAsync(CreateJVTypeDto jvTypeDto);
        Task<ReadJVTypeDto> UpdateAsync(int id, UpdateJVTypeDto jvTypeDto);
        Task<bool> DeleteAsync(int id);
    }
}
