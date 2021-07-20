using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;

namespace BankWebApiServices.Services.Abstract
{
    public interface IUserServices
    {
        public Task<User> GetUser(String username);
        public Task<User> EnterUser(User users);
        public Task<User> DeleteUsers(int id);
    }
}
