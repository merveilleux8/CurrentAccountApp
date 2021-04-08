using CurrentAccount.Account.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccount.Account.Service
{
    public interface ICustomerService
    {
        Task<bool> CheckIfCustomerExists(int customerId);
        Task<Customer> GetCustomer(int customerId);
        Task<List<Customer>> GetCustomers();

    }
}
