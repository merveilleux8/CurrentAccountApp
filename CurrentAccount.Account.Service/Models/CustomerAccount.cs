using System;
using System.Collections.Generic;
using System.Text;

namespace CurrentAccount.Account.Service.Models
{
    public class CustomerAccount
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string AccountId { get; set; }
    }
}
