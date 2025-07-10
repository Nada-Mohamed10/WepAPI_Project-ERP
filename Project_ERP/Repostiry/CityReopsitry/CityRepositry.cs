using Microsoft.EntityFrameworkCore;
using Project_ERP.Models;

namespace Project_ERP.Repostiry.CityReopsitry
{
    public class CityRepositry : GenericRepositry<City>, ICityRepositry
    {
        public CityRepositry(TaskContext db) : base(db)
        {
            this.db = db;
        }

        public IQueryable<City> GetAllWithBranch()
        {
            return db.Cities.Include(x=>x.Branch);  
        }

        public async Task<City> GetByIdWithBranchAsync(int id)
        {
            return await db.Cities.Include(x => x.Branch).FirstOrDefaultAsync(x => x.CityID == id);
        }

        public async Task<City> GetByNameAsync(string name)
        {
            return await db.Cities.Include(x => x.Branch)
                .FirstOrDefaultAsync(c =>
                    c.CityNameAr.ToLower().Contains(name.ToLower()) ||
                    c.CityNameEn.ToLower().Contains(name.ToLower()));
        }
    }
}
