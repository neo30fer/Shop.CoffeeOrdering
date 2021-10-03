using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.CoffeeOrdering.Domain.Entity;
using Shop.CoffeeOrdering.Domain.Interfaces;
using Shop.CoffeeOrdering.Services.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.CoffeeOrdering.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersDomain _usersDomain;
        private readonly AppSettings _appSettings;

        public UsersController(IUsersDomain authApplication, IOptions<AppSettings> appSettings)
        {
            _usersDomain = authApplication;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] Users user)
        {
            var authenticatedUser = _usersDomain.Authenticate(user.UserName, user.Password);
            if (authenticatedUser != null)
            {
                if (String.IsNullOrEmpty(user.FirstName))
                {
                    ModelState.AddModelError("FirstName", "The User First Name should not be empty");
                }

                if (String.IsNullOrEmpty(user.LastName))
                {
                    ModelState.AddModelError("LastName", "The User Last Name should not be empty");
                }

                authenticatedUser.Token = BuildToken(authenticatedUser);
                return Ok(authenticatedUser);
            }
            else
            {
                return BadRequest();
            }
        }

        private string BuildToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
