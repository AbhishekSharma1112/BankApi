using System;
using BankWebApiModels.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BankWebApiModels.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options):base(options)
        {

        }
     
        public virtual  DbSet<User>  Users { get; set; }
        public DbSet<Transactions> Transactions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(c => new { c.Id });
        }
        public class YourDbContextFactory : IDesignTimeDbContextFactory<UserContext>
        {
            public UserContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
                optionsBuilder.UseSqlServer("ConnectionStrings: DefaultConnection");

                return new UserContext(optionsBuilder.Options);
            }

            
        }
    }


}
