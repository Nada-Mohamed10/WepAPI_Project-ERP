using AutoMapper;
using Project_ERP.DTOs.SubAccounts_Levels;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.SubAccountLevelServices
{
    public class SubAccountLevelService : ISubAccountLevelService
    {
        UnitOfWork unit;
        IMapper map;
        public SubAccountLevelService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadSubAccounts_LevelsDto> AddAsync(CreateSubAccounts_LevelsDto subAccountLevelDto)
        {
            var subAccountLevel = map.Map<SubAccounts_Level>(subAccountLevelDto);
            await unit.SubAccount_LevelRepositry.AddAsync(subAccountLevel);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccounts_LevelsDto>(subAccountLevel);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subAccountLevel = await unit.SubAccount_LevelRepositry.GetByIdAsync(id);
            if (subAccountLevel == null)
                return false;
            unit.SubAccount_LevelRepositry.Delete(subAccountLevel);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadSubAccounts_LevelsDto>> GetAllAsync()
        {
           var subAccountLevels = await unit.SubAccount_LevelRepositry.GetAll();
           return map.Map<IEnumerable<ReadSubAccounts_LevelsDto>>(subAccountLevels);
        }

        public async Task<ReadSubAccounts_LevelsDto> GetByIdAsync(int id)
        {
            var subAccountLevel = await unit.SubAccount_LevelRepositry.GetByIdAsync(id);
            if(subAccountLevel == null) return null;
            return map.Map<ReadSubAccounts_LevelsDto>(subAccountLevel);
        }

        public async Task<ReadSubAccounts_LevelsDto> UpdateAsync(int id, UpdateSubAccounts_LevelsDto subAccountLevelDto)
        {
           var subAccountLevel = await unit.SubAccount_LevelRepositry.GetByIdAsync(id);
            if (subAccountLevel == null) return null;
            map.Map(subAccountLevelDto, subAccountLevel);
            unit.SubAccount_LevelRepositry.Update(subAccountLevel);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccounts_LevelsDto>(subAccountLevel);


        }
    }
}
