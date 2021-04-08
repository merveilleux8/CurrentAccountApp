using CurrentAccount.Account.Service.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentAccount.Account.Service.Impl
{
    public class CustomerService : ICustomerService
    {
        private IMemoryCache _memoryCache;

        public CustomerService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<bool> CheckIfCustomerExists(int customerId)
        {
            _memoryCache.TryGetValue("customers", out Object result);
            var customers = result as List<Customer>;
            return customers.Any(x => x.CustomerId == customerId);
        }

        public async Task<Customer> GetCustomer(int customerId)
        {
            _memoryCache.TryGetValue("customers", out Object result);
            var customers = result as List<Customer>;
            return customers.Where(x => x.CustomerId == customerId).FirstOrDefault();
        }

        public async Task<List<Customer>> GetCustomers()
        {
            _memoryCache.TryGetValue("customers", out Object result);
            return result as List<Customer>;
        }
    }
}
