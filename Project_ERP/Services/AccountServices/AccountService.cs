using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Project_ERP.DTOs.Account;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.AccountServices
{
    public class AccountService : IAccountService
    {
       private readonly UnitOfWork unit;
       private readonly IMapper map;
        public AccountService(UnitOfWork unit , IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadAccountDto> AddAsync(CreateAccountDto accountDto)
        {
            var account = map.Map<Account>(accountDto);
           await unit.AccountRepositry.AddAsync(account);
            unit.CompleteAsync();
            return  map.Map<ReadAccountDto>(account);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var account= await unit.AccountRepositry.GetByIdAsync(id);
            if (account == null)
                return false;
            unit.AccountRepositry.Delete(account);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadAccountDto>> GetAllAsync()
        {
            var accounts = await unit.AccountRepositry.GetAllWithBranch().ToListAsync();
            return map.Map<IEnumerable<ReadAccountDto>>(accounts);
           
        }

        public async Task<ReadAccountDto> GetByIdAsync(int id)
        {
           var account = await unit.AccountRepositry.GetByIdWithBranchAsync(id);
            if (account == null) return null;
            return map.Map<ReadAccountDto>(account);
        }
        public async Task<ReadAccountDto> GetByNameAsync(string name)
        {
            var account = await unit.AccountRepositry.GetByNameAsync(name);
            if (account == null) return null;
            return map.Map<ReadAccountDto>(account);
        }

        public async  Task<ReadAccountDto> UpdateAsync(int id, UpdateAccountDto accountDto)
        {
           var account = await unit.AccountRepositry.GetByIdAsync(id);
            if (account == null) return null;
            map.Map(accountDto, account);
            unit.AccountRepositry.Update(account);
           await  unit.CompleteAsync();
            return map.Map<ReadAccountDto>(account);
        }
    }
}
