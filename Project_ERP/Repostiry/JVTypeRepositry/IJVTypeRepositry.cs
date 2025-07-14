using Project_ERP.Models;

namespace Project_ERP.Repostiry.JVTypeRepositry
{
    public interface IJVTypeRepositry : IGenericRepositry<JVType>
    {
        IQueryable<JVType> GetAllWithBranch();

        Task<JVType> GetByIdWithBranch(int id);

        Task<JVType> GetByName(string name);

    }
}
