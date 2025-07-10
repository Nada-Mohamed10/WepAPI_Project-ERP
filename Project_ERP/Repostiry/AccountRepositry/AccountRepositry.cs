using Microsoft.EntityFrameworkCore;
using Project_ERP.Models;

namespace Project_ERP.Repostiry.AccountRepositry
{
    public class AccountRepositry : GenericRepositry<Account>, IAccountRepositry
    {
        public AccountRepositry(TaskContext db) : base(db)
        {
            this.db = db;
        }

        public IQueryable<Account> GetAllWithBranch()
        {
            return db.Accounts.Include(x => x.Branch);
        }

        public Task<Account> GetByIdWithBranchAsync(int id)
        {
            return db.Accounts.Include(x => x.Branch)
                .FirstOrDefaultAsync(x => x.AccountID == id);
        }

        public async Task<Account> GetByNameAsync(string name)
        {
            return await db.Accounts.Include(x => x.Branch)
                   
                .FirstOrDefaultAsync(a =>
                    a.AccountNameAr.ToLower().Contains(name.ToLower()) ||
                    a.AccountNameEn.ToLower().Contains(name.ToLower()));
        }


    }
}
