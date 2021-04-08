using CurrentAccount.Account.Service.Models;
using System.Collections.Generic;

namespace CurrentAccount.Account.Service
{
    public interface IAccountService
    {
        UserAccount AddAccount(int customerId, double initialCredit);
        List<UserAccount> GetAccounts();
        CustomerAccount GetAccountCustomer(string accountId);
    }
}
