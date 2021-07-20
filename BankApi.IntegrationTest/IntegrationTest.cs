using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BankApi.IntegrationTest
{
    public class IntegrationTest
    {
        [Fact]
        public async Task  Test1()
        {
            using (var client = new TestServerProvider().Client)
            {
                var response = await client.GetAsync("/api/User/GetUser/Abhishek");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
