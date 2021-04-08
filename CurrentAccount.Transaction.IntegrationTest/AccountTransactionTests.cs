using System;
using System.Threading.Tasks;
using Xunit;

namespace CurrentAccount.Transaction.IntegrationTest
{
    public class AccountTransactionTests
    {
        [Fact]
        public async Task GetTransactions_should_get_transactions_by_account()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;

        }
    }
}
