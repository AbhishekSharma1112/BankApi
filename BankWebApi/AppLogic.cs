using System;
using System.Collections.Generic;

namespace BankWebApi
{
    public class AppLogic
    {
 

        public double Update_Amount(double amount, double Balance, string transtype)
        {


            if (transtype == "deposit" || transtype == "Deposit")

            {
                Balance += amount;

            }
     

            if (transtype == "withdraw"||transtype == "Withdraw")
            {
                if (Balance > amount)
                {


                    Balance -= amount;

                }

                else
                    throw new Exception("Insufficient Balance");
                   

            }


            return (Balance);
        }
    }
}

