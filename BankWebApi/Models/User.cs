using System;
namespace BankWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public double Balance { get; set; }


    }
}
