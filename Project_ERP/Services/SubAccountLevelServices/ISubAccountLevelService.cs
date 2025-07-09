using Project_ERP.DTOs.SubAccounts_Levels;

namespace Project_ERP.Services.SubAccountLevelServices
{
    public interface ISubAccountLevelService
    {
        Task<IEnumerable<ReadSubAccounts_LevelsDto>> GetAllAsync();
        Task<ReadSubAccounts_LevelsDto> GetByIdAsync(int id);
        Task<ReadSubAccounts_LevelsDto> AddAsync(CreateSubAccounts_LevelsDto subAccountLevelDto);
        Task<ReadSubAccounts_LevelsDto> UpdateAsync(int id, UpdateSubAccounts_LevelsDto subAccountLevelDto);
        Task<bool> DeleteAsync(int id);
    }
}
