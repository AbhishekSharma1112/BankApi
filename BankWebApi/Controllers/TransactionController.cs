using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankWebApi.Data;
using BankWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : Controller
    {
        private readonly UserContext _context;

    public TransactionController(UserContext context)
    {
        _context = context;
    }

       
    [HttpPut("UpdateAmount/{transtype}/{amount}")]
        public async Task<ActionResult<Transaction>> UpdateAmount(double amount, string transtype)
        { 
        
            string username = HttpContext.User.Identity.Name;

            var user = await _context.Users.Where(i => i.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound();
            }
            int id = user.Id;
            Transactions transaction = new Transactions
            {
                ID = id,
                Amount = amount,
                TransactionType= transtype,
                Date = DateTime.Now

            };

            _context.Transactions.Add(transaction);

            AppLogic logic = new AppLogic();
            user.Balance = logic.Update_Amount(amount,user.Balance, transtype);
           

            _context.SaveChanges();
            return NoContent() ;

        }

    }

}