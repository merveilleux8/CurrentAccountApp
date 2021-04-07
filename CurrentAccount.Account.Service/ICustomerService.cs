using CurrentAccount.Account.Service.Models;
using System;
using System.Collections.Generic;

namespace CurrentAccount.Account.Service
{
    public interface ICustomerService
    {
        bool CheckIfCustomerExists(int customerId);
        Customer GetCustomer(int customerId);
        List<Customer> GetCustomers();

    }
}
