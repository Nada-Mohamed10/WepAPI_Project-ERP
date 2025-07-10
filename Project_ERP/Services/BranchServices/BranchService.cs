using AutoMapper;
using Project_ERP.DTOs.Branch;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        UnitOfWork unit;
        IMapper map;
        public BranchService(UnitOfWork unit , IMapper map ) 
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadBranchDto> AddAsync(CreateBranchDto branchDto)
        {
            var branch = map.Map<Branch>(branchDto);
           await  unit.BranchRepositry.AddAsync(branch);
            unit.CompleteAsync();
            return map.Map<ReadBranchDto>(branch);

        }

        public async  Task<bool> DeleteAsync(int id)
        {
            var branch = await unit.BranchRepositry.GetByIdAsync(id);
            if (branch == null)
                return false;
             unit.BranchRepositry.Delete(branch);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadBranchDto>> GetAllAsync()
        {
            var branchs = await unit.BranchRepositry.GetAll();

            return map.Map<IEnumerable<ReadBranchDto>>(branchs);
        }

        public async Task<ReadBranchDto> GetByIdAsync(int id)
        {
            var branch = await unit.BranchRepositry.GetByIdAsync(id);
            if (branch == null) return null;
            return map.Map<ReadBranchDto>(branch);
        }

        public async Task<ReadBranchDto> GetByNameAsync(string name)
        {
            var branch = await unit.BranchRepositry.GetByNameAsync(name);
            if (branch == null) return null;
            return map.Map<ReadBranchDto>(branch);
        }
        public async Task<ReadBranchDto> UpdateAsync(int id, UpdateBranchDto branchDto)
        {
            var branch = await unit.BranchRepositry.GetByIdAsync(id);
            if (branch == null) return null;
            map.Map(branchDto, branch);
            unit.BranchRepositry.Update(branch);
           await  unit.CompleteAsync();
            return map.Map<ReadBranchDto>(branch);
        }
    }
}
