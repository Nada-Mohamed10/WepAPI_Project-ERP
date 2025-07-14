using Project_ERP.Models;

namespace Project_ERP.Repostiry.JVRepositry
{
    public interface IJVRepositry:IGenericRepositry<JV>
    {
        IQueryable<JV> GetAllWithBranchAndJVType();

        Task<JV> GetByIdWithBranchAndJVType(int id);

        
    }
}
