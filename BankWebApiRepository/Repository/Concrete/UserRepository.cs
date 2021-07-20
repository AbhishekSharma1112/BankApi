using System;
using System.Linq;
using System.Threading.Tasks;
using BankWebApiModels.Data;
using BankWebApiModels.Models;
using BankWebApiRepository.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BankWebApiRepository.Repository.Concrete
{
    public class UserRepository : IUserRepository 
    {
        private readonly UserContext _usercontext;
        public UserRepository(UserContext userContext)
        {
            _usercontext = userContext;
        }


        public async  Task<User> DeleteUser(int id)
        {
            var user = _usercontext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _usercontext.Remove(user);
                await _usercontext.SaveChangesAsync();
            }

            return null;
            
        }

        public async Task<User> EnterUser(User users)
        {
            await _usercontext.Users.AddAsync(users);
            await _usercontext.SaveChangesAsync();
            return users ;
        }

        public async Task<User> GetUser(String username)
        {
            var user = await _usercontext.Users.Where(user => user.Username == username).FirstOrDefaultAsync();
            return user;
        }
        static void Main()
        {
        }
    }
}
