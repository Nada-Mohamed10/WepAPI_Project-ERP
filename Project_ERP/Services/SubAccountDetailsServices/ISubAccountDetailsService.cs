using Project_ERP.DTOs.SubAccounts_Details;

namespace Project_ERP.Services.SubAccountDetailsServices
{
    public interface ISubAccountDetailsService
    {
        Task<IEnumerable<ReadSubAccounts_DetailsDto>> GetAllAsync();
        Task<ReadSubAccounts_DetailsDto> GetByIdAsync(int id);
        Task<ReadSubAccounts_DetailsDto> AddAsync(CreateSubAccounts_DetailsDto subAccountDetailsDto);
        Task<ReadSubAccounts_DetailsDto> UpdateAsync(int id, UpdateSubAccounts_DetailsDto subAccountDetailsDto);
        Task<bool> DeleteAsync(int id);
        
    }
}
