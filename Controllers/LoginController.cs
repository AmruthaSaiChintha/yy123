using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YumYard.Models;

namespace YumYard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly Data _context;
        public LoginController(IConfiguration config, Data context)
        {
            _config = config;
            _context = context;
        }
        private string GenerateToken(User user,string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        //To authenticate user

        private User Authenticate(string email,string password)
        {
            var user = _context.user.FirstOrDefault(u => u.Email == email && u.Password == password);
            return user;
        }
        [HttpGet("login")]
        public IActionResult Login(string email, string password)
        {
            var user = Authenticate(email, password);
           
            if (user != null)
            {
                var role = user.Role;
                var token = GenerateToken(user, role);
                return Ok(new {Token=token,Role=role});
                
            }

            return NotFound("User not found or invalid credentials");
        }

    }
}
