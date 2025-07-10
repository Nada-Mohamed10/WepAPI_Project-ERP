using Project_ERP.Models;

namespace Project_ERP.Repostiry.CityReopsitry
{
    public interface ICityRepositry : IGenericRepositry<City>
    {
        IQueryable<City> GetAllWithBranch();
        Task<City> GetByIdWithBranchAsync(int id);

        Task<City> GetByNameAsync(string name);
    }
}
