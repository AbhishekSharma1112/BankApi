using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace BankWebApi.AcceptanceTest.Steps
{
    [Binding]
    public class GetUserAssertOkSteps

    {
        private readonly int Id= 1;

         HttpResponseMessage Response { get;  set; }

        [When(@"I perfom get request for  user with id ""(.*)""")]
        public async Task WhenIPerfomGetRequestForUserWithIdAsync()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5001/api/User/");
            Response = await httpClient.GetAsync("GetUserData?id=" + Id);


        }

        [Then(@"response status is '(.*)'")]
        public void ThenResponseStatusIs(int statuscode)
        {
            var expectedstatus = (HttpStatusCode)statuscode;
            Assert.Equal(expectedstatus, Response.StatusCode);

           
        }
    }
}
