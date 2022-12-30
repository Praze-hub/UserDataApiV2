using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WellaApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WellaApi.DatabaseContext;




namespace WellaApi.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase{
        private IConfiguration _config;
        private readonly AppDbContext _context;

        public LoginController(IConfiguration config, AppDbContext context)
        {
            _config = config;
            _context = context;
        }

      
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin){
            var user = Authenticate(userLogin);

            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User not found");
        }
        private string Generate(UserData user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.FirstName),
                new Claim(ClaimTypes.NameIdentifier, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires:DateTime.Now.AddMinutes(15),
            signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

            

        }
        private UserData Authenticate(UserLogin userLogin)
        {
            var currentUser = _context.UserDataTable.FirstOrDefault(o =>o.Username.ToLower()==userLogin.Username.ToLower()&&o.Password == userLogin.Password);
            if(currentUser != null)
            {
                return currentUser;

            }
            return null;
        }

    }
} 