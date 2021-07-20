using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;

namespace BankWebApiServices.Services.Abstract
{
    public interface ITransactionServices
    {
        public double UpdateAmount(double amount, double balance, string transtype);
        public Task<Transactions> AddTransactions(Transactions transactions);

    }
}
