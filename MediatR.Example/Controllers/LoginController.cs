using MediatR.Application.Interfaces;
using MediatR.Domain.Entities;
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


        public LoginController(IConfiguration config, ILogin login)
        {
            _config = config;
            _login = login;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("Invalid user request!!!");
            }
            if (_login.ValidateUser(user.UserName, user.Password))
            {
                var RoleName = _login.GetUserRole(user.id);
                if (RoleName.ToString() == "Admin")
                {

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
                else
                {
                    return NotFound();
                }

            }
            return Unauthorized();
        }
    }
}

