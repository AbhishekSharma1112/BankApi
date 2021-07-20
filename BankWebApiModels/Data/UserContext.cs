using System;
using BankWebApiModels.Models;
using Microsoft.EntityFrameworkCore;

namespace BankWebApiModels.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options):base(options)
        {

        }
     
        public DbSet<User>  Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

    }

    
}
