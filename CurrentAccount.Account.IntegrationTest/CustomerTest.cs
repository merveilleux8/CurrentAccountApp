using CurrentAccount.Account.Service.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CurrentAccount.Account.IntegrationTest
{
    public class CustomerTest
    {
        [Fact]
        public async Task GetCustomer_should_get_customers()
        {
            // Arrange
            using var httpClient = new TestClientProvider().HttpClient;

            // Act
            var response = await httpClient.GetAsync($"/api/customer");
            var customers = JsonConvert.DeserializeObject<List<Customer>>(await response.Content.ReadAsStringAsync());

            // Assert
            customers.Should().NotBeNullOrEmpty();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
