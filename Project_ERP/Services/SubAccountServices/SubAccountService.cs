using AutoMapper;
using Project_ERP.DTOs.SubAccount;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.SubAccountServices
{
    public class SubAccountService : ISubAccountService
    {
        UnitOfWork unit;
        IMapper map;
        public SubAccountService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }

        public async Task<ReadSubAccountDto> AddAsync(CreateSubAccountDto subAccountDto)
        {
           var SubAccount = map.Map<SubAccount>(subAccountDto);
            await unit.SubAccountRepositry.AddAsync(SubAccount);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccountDto>(SubAccount);

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subAccount = await unit.SubAccountRepositry.GetByIdAsync(id);
            if (subAccount == null)
                return false;
            unit.SubAccountRepositry.Delete(subAccount);
            unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadSubAccountDto>> GetAllAsync()
        {
            var SubAccounts = await unit.SubAccountRepositry.GetAll();

            return map.Map<IEnumerable<ReadSubAccountDto>>(SubAccounts);
        }

        public async Task<ReadSubAccountDto> GetByIdAsync(int id)
        {
            var SubAccount = await unit.SubAccountRepositry.GetByIdAsync(id);
            if (SubAccount == null) return null;
            return map.Map<ReadSubAccountDto>(SubAccount);
        }

        public async Task<ReadSubAccountDto> UpdateAsync(int id, UpdateSubAccountDto subAccountDto)
        {
            var SubAccount = await unit.SubAccountRepositry.GetByIdAsync(id);
            if (SubAccount == null) return null;
            map.Map(subAccountDto, SubAccount);
            unit.SubAccountRepositry.Update(SubAccount);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccountDto>(SubAccount);
        }
    }
}
