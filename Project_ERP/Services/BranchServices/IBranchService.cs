using Project_ERP.DTOs.Branch;

namespace Project_ERP.Services.BranchServices
{
    public interface IBranchService
    {
         Task<IEnumerable<ReadBranchDto>> GetAllAsync();
         Task<ReadBranchDto> GetByIdAsync(int id);

        Task<ReadBranchDto> GetByNameAsync(string name);
        Task<ReadBranchDto> AddAsync(CreateBranchDto branchDto);
        Task<ReadBranchDto> UpdateAsync(int id , UpdateBranchDto branchDto);
        Task<bool> DeleteAsync(int id);



    }
}
