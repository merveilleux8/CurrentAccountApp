using CurrentAccount.Account.Service.Exceptions;
using CurrentAccount.Account.Service.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CurrentAccount.Account.Service.Impl
{
    public class AccountService : IAccountService
    {
        private IMemoryCache _memoryCache;
        private ICustomerService _customerService;
        private static string transactionEndpoint;

        public AccountService(IMemoryCache memoryCache, ICustomerService customerService, IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _customerService = customerService;
            transactionEndpoint = configuration.GetValue<string>("transactionEndpoint");
        }

        public async Task<UserAccount> AddAccount(int customerId, double initialCredit)
        {
            try
            {
                var account = new UserAccount()
                {
                    CustomerId = customerId
                };

                if (initialCredit > 0)
                {
                    var transaction = new CreateTransactionModel()
                    {
                        AccountId = account.AccountId,
                        Credit = initialCredit
                    };
                    var client = new HttpClient();
                    var stringContent = new StringContent(JsonConvert.SerializeObject(transaction), Encoding.UTF8, "application/json");
                    var httpResponse = await client.PostAsync(transactionEndpoint, stringContent);

                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                        throw new ApiException("Account could not be created", System.Net.HttpStatusCode.FailedDependency);

                }
                _memoryCache.TryGetValue("accounts", out Object result);
                var accounts = result as List<UserAccount>;
                accounts.Add(account);
                _memoryCache.Set("accounts", accounts);
                return account;

            }
            catch
            {
                throw new ApiException("Account could not be created", System.Net.HttpStatusCode.FailedDependency);
            }
        }

        public async Task<List<UserAccount>> GetAccounts(int customerId)
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            var allAccounts = result as List<UserAccount>;
            return allAccounts.Where(x => x.CustomerId == customerId).ToList();
        }

        public async Task<CustomerAccount> GetAccountCustomer(string accountId)
        {
            _memoryCache.TryGetValue("accounts", out Object result);
            var accounts = result as List<UserAccount>;
            var account = accounts.Where(x => x.AccountId == accountId).FirstOrDefault();
            var customer = await _customerService.GetCustomer(account.CustomerId);
            var customerAccount = new CustomerAccount() { AccountId = account.AccountId, CustomerId = account.CustomerId, Name = customer.Name, Surname = customer.Surname };

            var client = new HttpClient();
            var httpResponse = await client.GetAsync($"{transactionEndpoint}/{accountId}");
            var content = await httpResponse.Content.ReadAsStringAsync();
            customerAccount.Transactions = JsonConvert.DeserializeObject<List<AccountTransaction>>(content);
            customerAccount.Transactions.ForEach(x => customerAccount.Balance += x.Credit);

            return customerAccount;
        }



    }
}
