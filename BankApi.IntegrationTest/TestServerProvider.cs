using System;
using System.Net.Http;
using BankWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace BankApi.IntegrationTest
{
    public class TestServerProvider
    {

        private TestServer server;

        public HttpClient Client { get; private set; }

        public TestServerProvider()
        {
            server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
       
    }
}
