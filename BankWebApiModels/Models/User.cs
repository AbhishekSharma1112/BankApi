using System;
using System.ComponentModel.DataAnnotations;

namespace BankWebApiModels.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string password { get; set; }
        public double Balance { get; set; }


        static void Main()
        {
        }
    }
}
