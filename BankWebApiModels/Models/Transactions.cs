using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankWebApiModels.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }
        [ForeignKey("User")]
        public int ID { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }




    }
}
