using System;
using System.Collections.Generic;
using System.Linq;
using BankWebApiModels.Data;
using BankWebApiModels.Models;
using BankWebApiRepository.Repository.Abstract;
using BankWebApiRepository.Repository.Concrete;
using FakeItEasy;

namespace BankApi.IntegrationTest.SharedData
{
    public class UserRepositoryMocker
    {
        public static IUserRepository CreateRepositoryWithMockedUsers()
        {
           // IDbContextFactory<UserContext> dbContextFactory = A.Fake<IDbContextFactory<UserContext>>();
            UserContext dbContext = FakeDbcontext.Fake<UserContext>();
            // A.CallTo(() => dbContextFactory.CreateDbContext(null)).Returns(dbContext);

            
            var data = new List<User>
            {
                new User {Id= 1, Username = "Abhishek" , password = "123456", Balance = 50 },
                new User { Id= 2, Username = "Shrey" , password = "1234567", Balance = 100},
                new User { Id= 3, Username = "Admin" , password = "1234567", Balance = 500},

            }.AsQueryable();

            dbContext.MockData(data.ToList(), () => dbContext.Users);

            return new UserRepository(dbContext);
        }
    }
}
