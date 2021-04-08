using CurrentAccount.Account.Service.Models;
using CurrentAccount.Account.ServiceHost.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CurrentAccount.Account.IntegrationTest
{
    public class AccountTest
    {
        [Fact]
        public async Task CreateAccount_should_return_account_without_transactions()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;

            // Act
            var accountModel = new CreateAccountModel()
            {
                CustomerId = 1,
                InitialCredit = 0
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(accountModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"/api/account", stringContent);
            var account = JsonConvert.DeserializeObject<UserAccount>(await response.Content.ReadAsStringAsync());

            // Assert
            account.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task CreateAccount_should_return_account_with_transactions()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;

            // Act
            var accountModel = new CreateAccountModel()
            {
                CustomerId = 1,
                InitialCredit = 5
            };
            /// todo: mock transaction api call -merve
            var stringContent = new StringContent(JsonConvert.SerializeObject(accountModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync($"/api/account", stringContent);
            var account = JsonConvert.DeserializeObject<UserAccount>(await response.Content.ReadAsStringAsync());

            // Assert
            //fails
            account.Should().NotBeNull();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
