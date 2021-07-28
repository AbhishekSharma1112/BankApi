using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BankApi.IntegrationTest.SharedData;
using BankWebApiRepository.Repository.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Xunit;

namespace BankApi.IntegrationTest
{
    public class UserControllerIntegrationTest
    {
        private readonly HttpClient _client;

        public UserControllerIntegrationTest()
        {
            _client = CreateHttpClientWithDependencies(UserRepositoryMocker.CreateRepositoryWithMockedUsers());

        }



        public HttpClient CreateHttpClientWithDependencies(IUserRepository userRepository)
        {
            var testServer = new TestServerProvider(
                serviceCollection =>
                {
                    serviceCollection.Replace(ServiceDescriptor.Singleton(userRepository));
                });
            var testClient = testServer.Client;
            return testClient;
        }



        [Fact]
        public async Task GetUser_Return_OkResult()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var Userid = 1 ;


            //Act
            var response = await _client.GetAsync($"api/User/GetUserData?id={Userid}").ConfigureAwait(true);




            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

        }
       
    }
}
