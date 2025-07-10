using Project_ERP.DTOs.Account;

namespace Project_ERP.Services.AccountServices
{
    public interface IAccountService
    {
        Task<IEnumerable<ReadAccountDto>> GetAllAsync();
        Task<ReadAccountDto> GetByIdAsync(int id);
        Task<ReadAccountDto> GetByNameAsync(string name);
        Task<ReadAccountDto> AddAsync(CreateAccountDto accountDto);
        Task<ReadAccountDto> UpdateAsync(int id, UpdateAccountDto accountDto);
        Task<bool> DeleteAsync(int id);
    }
}
