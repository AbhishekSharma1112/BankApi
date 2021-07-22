using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BankApi.IntegrationTest.SharedData;
using BankWebApiRepository.Repository.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace BankApi.IntegrationTest
{
    public class UserControllerIntegrationTest
    {
        private readonly HttpClient _client;

        public UserControllerIntegrationTest()
        {
            _client = CreateHttpClientWithDependencies(UserRepositoryMocker.CreateRepositoryWithMockedBuildingScore());

        }



        public HttpClient CreateHttpClientWithDependencies(IUserRepository userRepository)
        {
            var testServer = new TestServerProvider(
                serviceCollection =>
                {
                    serviceCollection.Replace(ServiceDescriptor.Singleton(userRepository));
                });
            var testClient = testServer.Client;
            //testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlNzWnNCTmhaY0YzUTlTNHRycFFCVEJ5TlJSSSIsImtpZCI6IlNzWnNCTmhaY0YzUTlTNHRycFFCVEJ5TlJSSSJ9.eyJhdWQiOiIyMWRjNDFhNS1jNDZhLTQwMDgtYjExOS1lM2E3ODgxZGNjZGEiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9lNzg1ZDg5Ni03Zjk2LTQwOTctOTA1MC0yYzMzYzA2ZmZmNTgvIiwiaWF0IjoxNTkxNjc5ODc3LCJuYmYiOjE1OTE2Nzk4NzcsImV4cCI6MTU5MTY4Mzc3NywiYWlvIjoiNDJkZ1lGQjlWN24wOWY1bm9RcHlWWXVuMytKcnk4emhTbnVkL00zZWZPL1pPVlhzbHhrQSIsImFtciI6WyJwd2QiXSwiZmFtaWx5X25hbWUiOiJtYW5hZ2VyZXh0IiwiZ2l2ZW5fbmFtZSI6InBvcnRmb2xpbyIsImhhc2dyb3VwcyI6InRydWUiLCJpcGFkZHIiOiIxMDMuMjMyLjIyNC4yMTkiLCJuYW1lIjoicG9ydGZvbGlvIG1hbmFnZXJleHQiLCJub25jZSI6ImUwODllNzFjLWQ0OGYtNGMwMy1hMTA3LTIwZmViZDE4Y2YzMyIsIm9pZCI6IjZiOTU4NDI1LWQwZTctNDY4MS04NDQ4LWZiMzYyNGRiZmIyNSIsInN1YiI6IlBZMTdpd1NCNTdWdXpLMUg5elBjTFNISlFwNG9MMW15NmtHX3lhSFNaNEkiLCJ0aWQiOiJlNzg1ZDg5Ni03Zjk2LTQwOTctOTA1MC0yYzMzYzA2ZmZmNTgiLCJ1bmlxdWVfbmFtZSI6InBvcnRmb2xpby5tYW5hZ2VyZXh0QGhvbmlkZW50aXR5ZGV2Lm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6InBvcnRmb2xpby5tYW5hZ2VyZXh0QGhvbmlkZW50aXR5ZGV2Lm9ubWljcm9zb2Z0LmNvbSIsInV0aSI6IndqdG5ldjBCU0VLcnhMSjJpSHh1QUEiLCJ2ZXIiOiIxLjAifQ.medIBsSm-lqx3jfuxXRLkiyLZohMAP9qhwxhEo3mRQlrFm7ulYjqOH_8u-uHYifw64wkEDkAovkBvpuZ1fA9xOuFx7GV9AzoKxe6AAio5UQuY0gIV3CidwgC9FTkbOEH5y7CJDENfJCqM1a7hJ-cfEK-9lKGJTMKA8XSzVRRdDXjgZn4337C4gMV8TDNp_JtlnsRlyBERFIeS-L3yfQfRD92J_PVDdABnooz6ujO9z3UEPxEOrjwdY0iJWJZJ3awO9-3Gb3d_t-qRj0PJk_pHFMU6UZ3UPy3nDxTPgcJxPJuMg6ka1jrwPZeBkjkRwpZnz7PQbqeL9QEuVfRGL2S8A");
            return testClient;
        }



        [Fact]
        public async Task GetUser_Return_OkResult()
        {
            //Arrange
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Act
            var response = await _client.GetAsync($"api/User/GetUser/Abhishek").ConfigureAwait(true);
            //Assert
            Assert.Equal(HttpStatusCode.OK,response.StatusCode);

        }
        
    }
}
