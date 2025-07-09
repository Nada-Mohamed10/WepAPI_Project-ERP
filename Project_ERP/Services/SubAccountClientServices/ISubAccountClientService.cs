using Project_ERP.DTOs.SubAccountsClient;

namespace Project_ERP.Services.SubAccountClientServices
{
    public interface ISubAccountClientService
    {
        Task<IEnumerable<ReadSubAccountsClientDto>> GetAllAsync();
        Task<ReadSubAccountsClientDto> GetByIdAsync(int id);
        Task<ReadSubAccountsClientDto> AddAsync(CreateSubAccountsClientDto subAccountClientDto);
        Task<ReadSubAccountsClientDto> UpdateAsync(int id, UpdateSubAccountsClientDto subAccountClientDto);
        Task<bool> DeleteAsync(int id);


    }
}
