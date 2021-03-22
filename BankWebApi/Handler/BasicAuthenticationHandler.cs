using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using BankWebApi.Data;
using BankWebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BankWebApi.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private UserContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            UserContext context,
            ISystemClock clock) : base(options, logger, encoder, clock)   
        {
            _context = context;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Authorization header was not found");

            try
            {

                var autheticationHeaderValues = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(autheticationHeaderValues.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string emailaddress = credentials[0];
                string password = credentials[1];

                User user = _context.Users.Where(user => user.Username == emailaddress && user.password == password).FirstOrDefault();

                if (user == null)
                    AuthenticateResult.Fail("Invalid usernam or password");
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Username) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }

            }
            catch(Exception)
            {
                return AuthenticateResult.Fail("Error ");
            }

           


            return AuthenticateResult.Fail("null");
        }
    }
}
