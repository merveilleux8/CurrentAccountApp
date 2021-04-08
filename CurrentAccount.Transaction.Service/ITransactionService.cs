using CurrentAccount.Transaction.Service.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrentAccount.Transaction.Service
{
    public interface ITransactionService
    {
        Task<AccountTransaction> AddTransaction(string accountId, double credit);
        Task<List<AccountTransaction>> GetTransactions(string accountId);
    }
}
