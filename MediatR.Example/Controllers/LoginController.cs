using MediatR.Application.Interfaces;
using MediatR.Domain.Entities;
using MediatR.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MediatR.Example.Controllers
{
    public class LoginController : BaseApiController
    {
        private IConfiguration _config;
        private ILogin _login;
        private ILogger<LoginController> _logger;


        public LoginController(IConfiguration config, ILogin login, ILogger<LoginController> logger)
        {
            _config = config;
            _login = login;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginBody user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (_login.ValidateUser(user.Email, user.Password))
            {
                // var Email = _login.GetUserByEmail(user.Email);
                // var RoleName = _login.GetUserRole(user);

                //  if (RoleName.ToString() == "Admin")
                // {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: _config["JWT:ValidIssuer"],
                    audience: _config["JWT:ValidAudience"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(6),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new JWTToken { Token = tokenString });
            }
            //    }
            else
            {
                return NotFound();
            }
            
            //return Unauthorized();
        }
    }
}

