using CurrentAccount.Account.ServiceHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace CurrentAccount.Account.IntegrationTest
{
    public class TestClientProvider : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient HttpClient { get; set; }

        public TestClientProvider()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.Development.json");

            _testServer = new TestServer(new WebHostBuilder().ConfigureAppConfiguration((context, conf) =>
            {
                conf.AddJsonFile(configPath);
            }).UseStartup<Startup>());

            HttpClient = _testServer.CreateClient();
        }

        public void Dispose()
        {
            _testServer?.Dispose();
            HttpClient?.Dispose();
        }
    }
}
