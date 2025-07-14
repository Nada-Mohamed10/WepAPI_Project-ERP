using Microsoft.EntityFrameworkCore;
using Project_ERP.Models;
using Project_ERP.Repostiry.JVRepositry;

namespace Project_ERP.Repostiry.JVTypeRepositry
{
    public class JVTypeRepositry : GenericRepositry<JVType>, IJVTypeRepositry
    {
    
         public JVTypeRepositry(TaskContext db) : base(db)
        {
            this.db = db;
        }
        public IQueryable<JVType> GetAllWithBranch()
        {
            return db.JVTypes.Include(x => x.Branch);
        }

        public async Task<JVType> GetByIdWithBranch(int id)
        {
            return await db.JVTypes.Include(x => x.Branch).FirstOrDefaultAsync(x=>x.JVTypeID == id);
        }

        public async Task<JVType> GetByName(string name)
        {
            return await db.JVTypes.Include(x => x.Branch)
                 .FirstOrDefaultAsync(a =>
                     a.JVTypeNameAr.ToLower().Contains(name.ToLower()) ||
                     a.JVTypeNameEn.ToLower().Contains(name.ToLower()));
        }
    }
    
}
