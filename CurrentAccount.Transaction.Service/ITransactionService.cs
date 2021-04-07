using CurrentAccount.Transaction.Service.Models;
using System;
using System.Collections.Generic;

namespace CurrentAccount.Transaction.Service
{
    public interface ITransactionService
    {
        AccountTransaction AddTransaction(string accountId, double credit);
        List<AccountTransaction> GetTransactions(string accountId);
    }
}
