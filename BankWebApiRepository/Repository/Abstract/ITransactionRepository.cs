using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;

namespace BankWebApiRepository.Repository.Abstract
{
    public interface ITransactionRepository
    {
        public  Task<Transactions> AddTransactions(Transactions transactions);
    }
}
