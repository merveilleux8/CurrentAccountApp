using System;

namespace CurrentAccount.Account.Service.Models
{
    public class UserAccount
    {
        public int CustomerId { get; set; }
        public string AccountId { get; set; } = Guid.NewGuid().ToString();
    }
}
