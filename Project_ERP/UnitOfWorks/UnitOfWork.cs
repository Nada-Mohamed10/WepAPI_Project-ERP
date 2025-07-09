using Project_ERP.Models;
using Project_ERP.Repostiry;

namespace Project_ERP.UnitOfWorks
{
    public class UnitOfWork
    {
        TaskContext db;
        public GenericRepositry<Account> AccountRepositry { get; }
        public GenericRepositry<Branch> BranchRepositry { get; }
        public GenericRepositry<City> CityRepositry { get; }
        public GenericRepositry<JV> JVRepositry { get; }
        public GenericRepositry<JVType> JVTypeRepositry { get; }
        public GenericRepositry<SubAccountsType> SubAccountTypeRepositry { get; }
        public GenericRepositry<SubAccount> SubAccountRepositry { get; }
        public GenericRepositry<JVDetail> JVDetailsRepositry { get; }
        public GenericRepositry<SubAccounts_Level> SubAccount_LevelRepositry { get; }
        public GenericRepositry<SubAccounts_Detail> SubAccount_DetailsRepositry { get; }

        public GenericRepositry<SubAccountsClient> SubAccountsClientRepositry { get; }
        public UnitOfWork(TaskContext db) 
        {
            this.db=db;
            AccountRepositry = new GenericRepositry<Account>(db);
            BranchRepositry = new GenericRepositry<Branch>(db);
            CityRepositry = new GenericRepositry<City>(db);
            JVRepositry = new GenericRepositry<JV>(db);
            JVTypeRepositry = new GenericRepositry<JVType>(db);
            SubAccountTypeRepositry = new GenericRepositry<SubAccountsType>(db);
            SubAccountRepositry = new GenericRepositry<SubAccount>(db);
            JVDetailsRepositry = new GenericRepositry<JVDetail>(db);
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
