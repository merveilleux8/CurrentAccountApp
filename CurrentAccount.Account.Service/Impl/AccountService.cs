using CurrentAccount.Account.Service.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CurrentAccount.Account.Service.Impl
{
    public class AccountService : IAccountService
    {
        private IMemoryCache _memoryCache;
        private ICustomerService _customerService;

        public AccountService(IMemoryCache memoryCache, ICustomerService customerService)
        {
            _memoryCache = memoryCache;
            _customerService = customerService;
        }

        public UserAccount AddAccount(int customerId, double initialCredit)
        {
            var account = new UserAccount()
            {
                CustomerId = customerId
            };
            _memoryCache.TryGetValue("accounts", out Object result);
            var accounts = result as List<UserAccount>;
            accounts.Add(new UserAccount()
            {
                CustomerId = customerId
            });
            _memoryCache.Set("accounts", accounts);

            if(initialCredit>0)
            {
                //todo: call transaction creation
                //_transactionService.AddTransaction(account.AccountId, initialCredit);
            }
            return account;
        }

        public List<UserAccount> GetAccounts()
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            return result as List<UserAccount>;
        }

        public CustomerAccount GetAccountCustomer(int customerId)
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            var accounts = result as List<UserAccount>;
            var account = accounts.Where(x => x.CustomerId == customerId).FirstOrDefault();
            var customer = _customerService.GetCustomer(customerId);
            var customerAccount = new CustomerAccount() { AccountId=account.AccountId, CustomerId=customerId, Name=customer.Name, Surname=customer.Surname};
            return customerAccount;
        }



    }
}
