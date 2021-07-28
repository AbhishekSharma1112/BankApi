using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace BankWebApi.AcceptanceTest.Steps
{
    [Binding]
    public class GetUserAssertOk
    {

        HttpResponseMessage ResponseMessage;
        HttpClient client = new HttpClient();

        [When("I make a Get request to '(.*)' ")]
        public async Task WhenImakeaGetRequestAsync(string endpoint)
        {
            client.BaseAddress = new Uri("https://localhost:5001/");
            ResponseMessage = await client.GetAsync("api/User/GetUserData/1");
           
        }

        [Then("the response status code is '(.*)'")]
        public void ThenresponseshouldbeOk(int statuscode)
        {
            var expectedResponse = (HttpStatusCode)statuscode;
            Assert.Equal(expectedResponse, ResponseMessage.StatusCode);
        }
    }
}
