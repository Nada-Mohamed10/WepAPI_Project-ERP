using Project_ERP.DTOs.SubAccount;

namespace Project_ERP.Services.SubAccountServices
{
    public interface ISubAccountService
    {
        Task<IEnumerable<ReadSubAccountDto>> GetAllAsync();
        Task<ReadSubAccountDto> GetByIdAsync(int id);
        Task<ReadSubAccountDto> AddAsync(CreateSubAccountDto subAccountDto);
        Task<ReadSubAccountDto> UpdateAsync(int id, UpdateSubAccountDto subAccountDto);
        Task<bool> DeleteAsync(int id);
    }
}
