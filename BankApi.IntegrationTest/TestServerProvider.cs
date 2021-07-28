using System;
using System.Net.Http;
using BankWebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankApi.IntegrationTest
{
    public class TestServerProvider
    {

        private readonly TestServer server;

        public HttpClient Client { get;}

        public TestServerProvider(Action<IServiceCollection> testServicesAction = null)
        {
            var webHostBuilder = new WebHostBuilder().UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build()).UseStartup<Startup>()
               .ConfigureTestServices(testServicesAction ?? (collection => { }));

            server = new TestServer(webHostBuilder);

            Client = server.CreateClient();
        }

        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
       
    }
}
