using Microsoft.EntityFrameworkCore;
using Project_ERP.DTOs.JVDetails;
using Project_ERP.Models;

namespace Project_ERP.Repostiry.JVDetailsRepositry
{
    public class JVDetailsRepository : GenericRepositry<JVDetail>, IJVDetailsRepository
    {
        private readonly TaskContext db;

        public JVDetailsRepository(TaskContext db) : base(db)
        {
            this.db = db;
        }

        public IQueryable<JVDetail> GetAllWithAccount()
        {
            return db.JVDetails
                     .Include(jv => jv.Account)
                     .Include(jv => jv.Branch)
                     .Include(jv => jv.SubAccount);
        }

    }
}
