using System;

namespace CurrentAccount.Transaction.Service.Models
{
    public class AccountTransaction
    {
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public string AccountId { get; set; }
        public double Credit { get; set; }
    }
}
