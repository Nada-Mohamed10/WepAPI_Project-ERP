using Project_ERP.Models;

namespace Project_ERP.Repostiry.BranchRepositry
{
    public interface IBranchRepositry : IGenericRepositry<Branch>
    {
 
        Task<Branch> GetByNameAsync(string name);
    }
}
