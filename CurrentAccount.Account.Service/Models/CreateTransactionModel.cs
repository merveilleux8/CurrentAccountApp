using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Account.Service.Models
{
    public class CreateTransactionModel
    {
        public string AccountId { get; set; }
        public double Credit { get; set; }
    }
}
