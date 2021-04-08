using System;

namespace CurrentAccount.Account.Service.Models
{
    public class AccountTransaction
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public double Credit { get; set; }
    }
}
