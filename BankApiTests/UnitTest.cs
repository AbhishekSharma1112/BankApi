using System;
using Xunit;
using BankWebApi;
using BankWebApiServices.Services.Concrete;
namespace BankApiTests
{
    using BankWebApiModels.Data;
    using BankWebApiRepository.Repository.Concrete;
    using FakeItEasy;

    public class UnitTest
    {

        [Theory]
        [InlineData(100,100,200)]
        [InlineData(100,200,300)]
        [InlineData(30,500,530)]
         public void Return_OkResult_DepositFunctio(double amount, double balance, double result)
         {

            var obj = A.Fake<TransactionServices>();

            double bal = obj.UpdateAmount(amount, balance, "deposit");
            Assert.Equal(result, bal);

         }

        [Theory]
        [InlineData(100, 100, 300)]
        [InlineData(100, 200, 200)]
        [InlineData(30, 500, 500)]
        public void Return_BadResult_DepositFunction(double amount , double balance , double result )
        {
            var obj = A.Fake<TransactionServices>();
            double Bal = obj.UpdateAmount(amount, balance, "deposit");
            Assert.NotEqual(result, Bal);
        }

        [Theory]
        [InlineData(100, 110, 10)]
        [InlineData(100, 200, 100)]
        [InlineData(30, 500, 470)]
        public void Return_OkResult_WithDrawFunction(double amount, double balance, double result)
        {
            var obj = A.Fake<TransactionServices>();

            double Bal = obj.UpdateAmount(amount,balance, "Withdraw");
            Assert.Equal(result, Bal);

        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(100, 50)]
        [InlineData(30, 10)]
        public void Return_BadResult_WithdrawFunction(double amount, double balance)
        {
            var obj = A.Fake<TransactionServices>();

            var ex = Assert.Throws<Exception>(() => obj.UpdateAmount(amount,balance, "Withdraw"));
            Assert.Equal("Insufficient Balance", ex.Message);
        }

      
    }
}

