using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using BankWebApiModels.Data;
using BankWebApiModels.Models;
using BankWebApiServices.Services.Abstract;
using BankWebApiServices.Services.Concrete;
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
        private readonly ITransactionServices _transaction;
        private readonly IUserServices _userServices;
        private readonly UserContext _userContext;

        public TransactionController(ITransactionServices transaction, IUserServices userServices,UserContext userContext)
    {
        _transaction = transaction;
            _userServices = userServices;
            _userContext = userContext;

    }

       
    [HttpPut("UpdateAmount/{transtype}/{amount}")]
        public async Task<ActionResult<Transaction>> UpdateAmount(double amount, string transtype)
        { 
        
            string username = HttpContext.User.Identity.Name;

            var user = await _userServices.GetUser(username);

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

           await _transaction.AddTransactions(transaction);

            user.Balance = _transaction.UpdateAmount(amount, user.Balance, transtype);
            _userContext.SaveChanges();

            return NoContent() ;

        }

    }

}