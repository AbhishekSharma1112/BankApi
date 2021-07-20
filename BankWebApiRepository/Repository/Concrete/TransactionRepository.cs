using System;
using System.Threading.Tasks;
using BankWebApiModels.Data;
using BankWebApiModels.Models;
using BankWebApiRepository.Repository.Abstract;

namespace BankWebApiRepository.Repository.Concrete
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly UserContext _usercontext;
        public TransactionRepository(UserContext userContext)
        {
            _usercontext = userContext;
        }

        public async Task<Transactions> AddTransactions(Transactions transactions)
        {
            await _usercontext.Transactions.AddAsync(transactions);
            await _usercontext.SaveChangesAsync();

            return null;
        }

        
    }
}
