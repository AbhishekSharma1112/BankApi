using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;

namespace BankWebApiRepository.Repository.Abstract
{
    public interface IUserRepository
    {
        public Task<User> GetUser(int id);
        public Task<User> EnterUser(User users);
        public Task<User> DeleteUser(int id);
       
        
    }
}
