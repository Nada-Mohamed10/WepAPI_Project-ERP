using AutoMapper;
using Project_ERP.DTOs.SubAccountType;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.SubAccountTypeServices
{
    public class SubAccountTypeService : ISubAccountTypeService
    {
        UnitOfWork unit;
        IMapper map;
        public SubAccountTypeService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadSubAccountTypeDto> AddAsync(CreateSubAccountTypeDto subAccountTypeDto)
        {
            var subAccountType = map.Map<SubAccountsType>(subAccountTypeDto);
            unit.SubAccountTypeRepositry.AddAsync(subAccountType);
            unit.CompleteAsync();
            return map.Map<ReadSubAccountTypeDto>(subAccountType);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var subAccountType = await unit.SubAccountTypeRepositry.GetByIdAsync(id);
            unit.SubAccountTypeRepositry.Delete(subAccountType);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadSubAccountTypeDto>> GetAllAsync()
        {
            var subAccountTypes = await unit.SubAccountTypeRepositry.GetAll();

            return map.Map<IEnumerable<ReadSubAccountTypeDto>>(subAccountTypes);
        }

        public async Task<ReadSubAccountTypeDto> GetByIdAsync(int id)
        {
           var subAccountType = await unit.SubAccountTypeRepositry.GetByIdAsync(id);
            if (subAccountType == null) return null;
            return map.Map<ReadSubAccountTypeDto>(subAccountType);
        }

        public async Task<ReadSubAccountTypeDto> UpdateAsync(int id, CreateSubAccountTypeDto subAccountTypeDto)
        {
           var subAccountType = await unit.SubAccountTypeRepositry.GetByIdAsync(id);
            if (subAccountType == null) return null;
             map.Map(subAccountTypeDto, subAccountType);
             unit.SubAccountTypeRepositry.Update(subAccountType);
            await unit.CompleteAsync();
             return map.Map<ReadSubAccountTypeDto>(subAccountType);
        }
    }
}
