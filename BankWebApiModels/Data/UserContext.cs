using System;
using BankWebApiModels.Models;
using Microsoft.EntityFrameworkCore;

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
    }


}
