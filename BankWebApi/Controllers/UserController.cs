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

            if(user == null)
            {
                return NotFound();
            }

            return user;

        }
        [HttpPost("EnterUser")]
        public ActionResult EnterUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return NoContent();

        }
        [HttpDelete("{Id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            _context.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }

      

    }
}
