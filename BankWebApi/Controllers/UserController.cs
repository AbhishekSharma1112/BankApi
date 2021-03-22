using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankWebApi.Data;
using BankWebApi.Models;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BankWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        [HttpGet ("GetUser")]
        public async Task<ActionResult<User>> GetUser()
        {
            string username = HttpContext.User.Identity.Name;
            var user = await _context.Users.Where(user => user.Username == username).FirstOrDefaultAsync();

            user.password = null;
            if(user == null)
            {
                return NotFound();
            }

            return user;

        }
        [HttpPost("EnterUser")]
        public ActionResult EnterUser(User p)
        {
            _context.Users.Add(p);
            _context.SaveChanges();
            return NoContent();

        }

        [HttpPut("UpdateAmount/{cmd}/{a}")]
        public async Task<ActionResult<User>> UpdateAmount(int a, string cmd)
        {
            string username = HttpContext.User.Identity.Name;

            var per = await _context.Users.Where(i => i.Username == username).FirstOrDefaultAsync();
            if (cmd == "deposit")
            {
                per.Balance += a;

            }
            if (cmd == "withdraw")
            {
                per.Balance -= a;
            }
            _context.SaveChanges();
            return NoContent();

        }


    }
}
