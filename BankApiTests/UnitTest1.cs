using System;
using Xunit;
using BankWebApi;

namespace BankApiTests
{
    
    public class UnitTest1
    {

        [Fact]
         public void Return_OkResult_DepositFunctio()
          {
                AppLogic logic = new AppLogic();
                double Bal = logic.Update_Amount(100, 100, "deposit");
                Assert.Equal(200,Bal);
            }
        [Fact]
        public void Return_BadResult_DepositFunction()
        {
            AppLogic logic = new AppLogic();
            double Bal = logic.Update_Amount(10, 100, "deposit");
            Assert.NotEqual(200, Bal);
        }
        [Fact]
        public void Return_OkResult_WithDrawFunction()
        {
            AppLogic logic = new AppLogic();
            double Bal = logic.Update_Amount(100, 200, "Withdraw");
            Assert.Equal(100, Bal);

        }
        [Fact]
        public void Return_BadResult_WithdrawFunction()
        {

            AppLogic logic = new AppLogic();

            var ex = Assert.Throws<Exception>(() => logic.Update_Amount(100, 50, "Withdraw"));
            Assert.Equal("Insufficient Balance", ex.Message);
        }

      
    }
}

