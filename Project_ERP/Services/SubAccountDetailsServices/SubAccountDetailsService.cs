using AutoMapper;
using Project_ERP.DTOs.SubAccounts_Details;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.SubAccountDetailsServices
{
    public class SubAccountDetailsService : ISubAccountDetailsService
    {
        UnitOfWork unit;
        IMapper map;
        public SubAccountDetailsService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadSubAccounts_DetailsDto> AddAsync(CreateSubAccounts_DetailsDto subAccountDetailsDto)
        {
            var subAccountDetails = map.Map<SubAccounts_Detail>(subAccountDetailsDto);
            await unit.SubAccount_DetailsRepositry.AddAsync(subAccountDetails);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccounts_DetailsDto>(subAccountDetails);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var subAccountDetails = await unit.SubAccount_DetailsRepositry.GetByIdAsync(id);
            if (subAccountDetails == null)
                return false;
            unit.SubAccount_DetailsRepositry.Delete(subAccountDetails);
            await unit.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<ReadSubAccounts_DetailsDto>> GetAllAsync()
        {
           var subAccountDetails = await unit.SubAccount_DetailsRepositry.GetAll();
            return map.Map<IEnumerable<ReadSubAccounts_DetailsDto>>(subAccountDetails);

        }

        public async Task<ReadSubAccounts_DetailsDto> GetByIdAsync(int id)
        {
           var subAccountDetails = await unit.SubAccount_DetailsRepositry.GetByIdAsync(id);
            if (subAccountDetails == null) return null;
            return map.Map<ReadSubAccounts_DetailsDto>(subAccountDetails);
        }

      

        public async Task<ReadSubAccounts_DetailsDto> UpdateAsync(int id, UpdateSubAccounts_DetailsDto subAccountDetailsDto)
        {
            var subAccountDetails = await unit.SubAccount_DetailsRepositry.GetByIdAsync(id);
            if (subAccountDetails == null) return null;
            map.Map(subAccountDetailsDto, subAccountDetails);
            unit.SubAccount_DetailsRepositry.Update(subAccountDetails);
            await unit.CompleteAsync();
            return map.Map<ReadSubAccounts_DetailsDto>(subAccountDetails);
        }

    }
}
