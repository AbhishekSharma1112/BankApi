using System;
using Xunit;
using BankWebApi;
using BankWebApiServices.Services.Concrete;
namespace BankApiTests
{
    using BankWebApiModels.Data;
    using BankWebApiRepository.Repository.Concrete;
    using FakeItEasy;

    public class UnitTest1
    {

        [Fact]
         public void Return_OkResult_DepositFunctio()
         {

            var obj = A.Fake<TransactionServices>();

            double bal = obj.UpdateAmount(100, 100, "deposit");
            Assert.Equal(200, bal);

         }


        [Fact]
        public void Return_BadResult_DepositFunction()
        {
            var obj = A.Fake<TransactionServices>();
            double Bal = obj.UpdateAmount(10, 100, "deposit");
            Assert.NotEqual(200, Bal);
        }
        [Fact]
        public void Return_OkResult_WithDrawFunction()
        {
            var obj = A.Fake<TransactionServices>();

            double Bal = obj.UpdateAmount(100, 200, "Withdraw");
            Assert.Equal(100, Bal);

        }
        [Fact]
        public void Return_BadResult_WithdrawFunction()
        {
            var obj = A.Fake<TransactionServices>();

            var ex = Assert.Throws<Exception>(() => obj.UpdateAmount(100, 50, "Withdraw"));
            Assert.Equal("Insufficient Balance", ex.Message);
        }

      
    }
}

