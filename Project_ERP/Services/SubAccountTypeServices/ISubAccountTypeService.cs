using Project_ERP.DTOs.SubAccountType;

namespace Project_ERP.Services.SubAccountTypeServices
{
    public interface ISubAccountTypeService
    {
        Task<IEnumerable<ReadSubAccountTypeDto>> GetAllAsync();
        Task<ReadSubAccountTypeDto> GetByIdAsync(int id);
        Task<ReadSubAccountTypeDto> AddAsync(CreateSubAccountTypeDto subAccountTypeDto);
        Task<ReadSubAccountTypeDto> UpdateAsync(int id, CreateSubAccountTypeDto subAccountTypeDto);
        Task<bool> DeleteAsync(int id);
    }
}
