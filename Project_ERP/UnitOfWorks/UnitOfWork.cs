using Project_ERP.Models;
using Project_ERP.Repostiry;
using Project_ERP.Repostiry.AccountRepositry;
using Project_ERP.Repostiry.BranchRepositry;
using Project_ERP.Repostiry.CityReopsitry;
using Project_ERP.Repostiry.JVDetailsRepositry;
using Project_ERP.Repostiry.JVRepositry;
using Project_ERP.Repostiry.JVTypeRepositry;

namespace Project_ERP.UnitOfWorks
{
    public class UnitOfWork
    {
        TaskContext db;
        public IAccountRepositry AccountRepositry { get; }
        public IBranchRepositry BranchRepositry { get; }
        public ICityRepositry CityRepositry { get; }
       public IJVRepositry JVRepositry { get; }
       public IJVTypeRepositry JVTypeRepositry { get; }
        public GenericRepositry<SubAccountsType> SubAccountTypeRepositry { get; }
        public GenericRepositry<SubAccount> SubAccountRepositry { get; }

        public IJVDetailsRepository JVDetailsRepositry { get; }
        public GenericRepositry<SubAccounts_Level> SubAccount_LevelRepositry { get; }
        public GenericRepositry<SubAccounts_Detail> SubAccount_DetailsRepositry { get; }

        public GenericRepositry<SubAccountsClient> SubAccountsClientRepositry { get; }
        public UnitOfWork(TaskContext db)
        {
            this.db = db;
            AccountRepositry = new AccountRepositry(db);    
            BranchRepositry = new BranchRepositry(db);
            CityRepositry = new CityRepositry(db);
            JVRepositry = new JVRepositry(db);
            JVTypeRepositry = new JVTypeRepositry(db);
            SubAccountTypeRepositry = new GenericRepositry<SubAccountsType>(db);
            SubAccountRepositry = new GenericRepositry<SubAccount>(db);
            JVDetailsRepositry = new JVDetailsRepository(db);
            SubAccount_LevelRepositry = new GenericRepositry<SubAccounts_Level>(db);
            SubAccount_DetailsRepositry = new GenericRepositry<SubAccounts_Detail>(db);
            SubAccountsClientRepositry = new GenericRepositry<SubAccountsClient>(db);
        }
        public async Task<int> CompleteAsync()
        {
            return await db.SaveChangesAsync();
        }
    }
    
}
