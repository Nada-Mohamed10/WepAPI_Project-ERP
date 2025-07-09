using AutoMapper;
using Project_ERP.DTOs.SubAccountsClient;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.SubAccountClientServices
{
    public class SubAccountClientService : ISubAccountClientService
    {
        UnitOfWork unit;
        IMapper map;
        public SubAccountClientService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadSubAccountsClientDto> AddAsync(CreateSubAccountsClientDto subAccountClientDto)
        {
           var subAccountClient = map.Map<SubAccountsClient>(subAccountClientDto);
            await unit.SubAccountsClientRepositry.AddAsync(subAccountClient);
          await  unit.CompleteAsync();
            return map.Map<ReadSubAccountsClientDto>(subAccountClient);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subAccountClient = await unit.SubAccountsClientRepositry.GetByIdAsync(id);
            if (subAccountClient == null)
                return false;
            unit.SubAccountsClientRepositry.Delete(subAccountClient);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadSubAccountsClientDto>> GetAllAsync()
        {
           var subAccountClients = await unit.SubAccountsClientRepositry.GetAll();
            return map.Map<IEnumerable<ReadSubAccountsClientDto>>(subAccountClients);
        }

        public async Task<ReadSubAccountsClientDto> GetByIdAsync(int id)
        {
            var subAccountClient = await unit.SubAccountsClientRepositry.GetByIdAsync(id);
            if (subAccountClient == null) return null;
            return map.Map<ReadSubAccountsClientDto>(subAccountClient);
        }

        public async Task<ReadSubAccountsClientDto> UpdateAsync(int id, UpdateSubAccountsClientDto subAccountClientDto)
        {
          var subAccountClient = await unit.SubAccountsClientRepositry.GetByIdAsync(id);
            if (subAccountClient == null) return null;
            map.Map(subAccountClientDto, subAccountClient);
            unit.SubAccountsClientRepositry.Update(subAccountClient);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccountsClientDto>(subAccountClient);
        }
    }
}
