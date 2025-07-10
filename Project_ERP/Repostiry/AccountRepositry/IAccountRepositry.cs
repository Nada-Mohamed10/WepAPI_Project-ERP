using Project_ERP.Models;

namespace Project_ERP.Repostiry.AccountRepositry
{
    public interface IAccountRepositry : IGenericRepositry<Account>
    {
        IQueryable<Account> GetAllWithBranch();
        Task<Account> GetByIdWithBranchAsync(int id);

        Task<Account> GetByNameAsync(string name);
    }
}
