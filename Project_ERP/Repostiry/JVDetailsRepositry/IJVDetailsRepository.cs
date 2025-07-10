using Project_ERP.Models;

namespace Project_ERP.Repostiry.JVDetailsRepositry
{
    public interface IJVDetailsRepository : IGenericRepositry<JVDetail>
    {
        IQueryable<JVDetail> GetAllWithAccount();
    }
}