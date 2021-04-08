using CurrentAccount.Transaction.Service.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Transaction.Service.Impl
{
    public class TransactionService : ITransactionService
    {
        private IMemoryCache _memoryCache;

        public TransactionService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public async Task<AccountTransaction> AddTransaction(string accountId, double credit)
        {
            _memoryCache.TryGetValue("transactions", out Object result);
            var transactions = result as List<AccountTransaction>;
            var transaction = new AccountTransaction()
            {
                AccountId = accountId,
                Credit = credit
            };
            transactions.Add(transaction);
            _memoryCache.Set("transactions", transactions);
            return transaction;
        }

        public async Task<List<AccountTransaction>> GetTransactions(string accountId)
        {
            _memoryCache.TryGetValue("transactions", out Object result);
            var allTransactions = result as List<AccountTransaction>;
            return allTransactions.Where(x => x.AccountId == accountId).ToList();
        }
    }
}
