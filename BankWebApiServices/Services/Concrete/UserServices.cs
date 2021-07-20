using System;
using System.Threading.Tasks;
using BankWebApiModels.Models;
using BankWebApiRepository.Repository.Abstract;
using BankWebApiRepository.Repository.Concrete;
using BankWebApiServices.Services.Abstract;

namespace BankWebApiServices.Services.Concrete
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userrepository;
        public UserServices(IUserRepository userRepository)
        {
            _userrepository = userRepository;
        }

        public async Task<User> DeleteUsers(int id)
        {
           await _userrepository.DeleteUser(id);
            return null;
        }

        public async Task<User> EnterUser(User users)
        {
            await _userrepository.EnterUser(users);
            return users;
        }

        public async  Task<User> GetUser(string username)
        {
           var user = await _userrepository.GetUser(username);
            return user;
        }
        static void Main()
        {
        }
    }
}
