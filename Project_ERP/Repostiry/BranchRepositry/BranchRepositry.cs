using Microsoft.EntityFrameworkCore;
using Project_ERP.Models;

namespace Project_ERP.Repostiry.BranchRepositry
{
    public class BranchRepositry : GenericRepositry<Branch>, IBranchRepositry
    {
        public BranchRepositry(TaskContext db) : base(db)
        {
        }

        public  Task<Branch> GetByNameAsync(string name)
        {
            return  db.Branches.FirstOrDefaultAsync(a =>
                    a.BranchNameAr.ToLower().Contains(name.ToLower()) ||
                    a.BranchNameEn.ToLower().Contains(name.ToLower()));
        }

       
    }
}
