using Microsoft.EntityFrameworkCore;
using Project_ERP.DTOs.JVDetails;
using Project_ERP.Models;

namespace Project_ERP.Repostiry
{
    public class JVDetailsRepository : GenericRepositry<JVDetail>, IJVDetailsRepository
    {
        public JVDetailsRepository(TaskContext db) : base(db) 
        {
        }

        public IQueryable<JVDetail> GetAllWithAccount()
        {
            return db.JVDetails.Include(jv => jv.Account);
        }
    }
}
