using CurrentAccount.Account.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccount.Account.Service
{
    public interface IAccountService
    {
        Task<UserAccount> AddAccount(int customerId, double initialCredit);
        Task<List<UserAccount>> GetAccounts(int customerId);
        Task<CustomerAccount> GetAccountCustomer(string accountId);
    }
}
