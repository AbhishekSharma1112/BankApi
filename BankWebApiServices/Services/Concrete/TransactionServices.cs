using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;
using BankWebApiRepository.Repository.Abstract;
using BankWebApiRepository.Repository.Concrete;
using BankWebApiServices.Services.Abstract;

namespace BankWebApiServices.Services.Concrete
{
    public class TransactionServices : ITransactionServices
    {
        private readonly ITransactionRepository _transaction;
        public TransactionServices(ITransactionRepository transaction)
        {
            _transaction = transaction;
        }

        public async Task<Transactions> AddTransactions(Transactions transactions)
        {
            await _transaction.AddTransactions(transactions);
            return null;
            
        }

        public double UpdateAmount(double amount, double Balance, string transtype)
        {
            if (transtype == "deposit" || transtype == "Deposit")
            {
                Balance += amount;

            }


            if (transtype == "withdraw" || transtype == "Withdraw")
            {
                if (Balance > amount)
                {


                    Balance -= amount;

                }

                else
                    throw new Exception("Insufficient Balance");


            }


            return Balance;
        }
    }
}
