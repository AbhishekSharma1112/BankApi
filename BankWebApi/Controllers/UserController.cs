using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BankWebApiServices.Services.Concrete;
using BankWebApiModels.Models;
using BankWebApiServices.Services.Abstract;

namespace BankWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
         private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("GetUserData")]
        public async Task<IActionResult> GetUser([FromQuery]int id)
        {
            var user = await  _userServices.GetUser(id);


            if (user == null)
            {
                return NotFound();
            }


            return Ok(user);
            

        }
        [HttpPost("EnterUser")]
        public async Task<ActionResult> EnterUser(User user)
        {
            await _userServices.EnterUser(user);
            return NoContent();

        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
           await  _userServices.DeleteUsers(id);
            return NoContent();
        }

      

    }
}
