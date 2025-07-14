using Microsoft.EntityFrameworkCore;
using Project_ERP.Models;
using Project_ERP.Models;

namespace Project_ERP.Repostiry.JVRepositry
{
    public class JVRepositry : GenericRepositry<JV>, IJVRepositry
    {
        public JVRepositry(TaskContext db) : base(db)
        {
            this.db=db;
        }

        public IQueryable<JV> GetAllWithBranchAndJVType()
        {
            return db.JVs.Include(x => x.Branch).ThenInclude(j=>j.JVTypes);
        }

        public async Task<JV> GetByIdWithBranchAndJVType(int id)
        {
            return await db.JVs.Include(x => x.Branch).ThenInclude(x=>x.JVTypes).FirstOrDefaultAsync(x => x.JVID == id);
        }

       
    }
}
