using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Account.ServiceHost.Models
{
    public class CreateAccountModel
    {
        public int CustomerId { get; set; }
        public double InitialCredit { get; set; }
    }
}
