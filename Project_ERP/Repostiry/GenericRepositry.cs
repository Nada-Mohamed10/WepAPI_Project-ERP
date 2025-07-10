using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Project_ERP.Models;

namespace Project_ERP.Repostiry
{
    public class GenericRepositry<Tentity> : IGenericRepositry<Tentity> where  Tentity : class
    {
       public TaskContext db;
        public GenericRepositry(TaskContext db)
        { 
            this.db = db;
        }

        public async Task<IEnumerable<Tentity>> GetAll()
        {
            return await db.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
            return await db.Set<Tentity>().FindAsync(id);
        }

        public async Task<Tentity> GetByNameAsync(string name)
        {
            return await db.Set<Tentity>().FindAsync(name);
        }

        public async Task AddAsync(Tentity tentity)
        {
          await  db.Set<Tentity>().AddAsync(tentity);
        }
        public void Update(Tentity tentity)
        {
            db.Entry(tentity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Tentity tentity)
        {
            db.Set<Tentity>().Remove(tentity);
        }

        
    }
}
