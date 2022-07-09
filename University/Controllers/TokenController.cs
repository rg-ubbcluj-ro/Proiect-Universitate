using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using University.Models;
using University.Utils;

namespace Univerity.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly UniversityContext _context;
        private readonly PasswordHasher<UserInfo> passwordHasher;
        public TokenController(IConfiguration config, UniversityContext context)
        {
            _configuration = config;
            _context = context;
            this.passwordHasher = new PasswordHasher<UserInfo>();
        }

        /*[HttpPost]
        [Route("confirm/{username}")]
        public IActionResult Confirm(string username)
        {
            var userInfo = _context.UserInfos.FirstOrDefault(x => x.Username == username);
            if (userInfo == null)
            {
                return NotFound();
            }
            userInfo.IsConfirmed = true;
            _context.SaveChangesAsync();
            return Ok();
        }*/

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Post(UserInfo _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, PasswordUtils.ComputeSha256Hash(_userData.Password));

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Email", user.Email),
                        new Claim("Password", user.Password)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(120),
                        signingCredentials: signIn);

                    return Ok(new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Oare de ce nu se logheaza?");
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserInfo>> Register(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                return BadRequest();
            }
            if (await _context.UsersItems.AnyAsync(item => item.Email == userInfo.Email))
            {
                return BadRequest("Email already exists");
            }
            if (userInfo.Email == null || userInfo.Email.Length < 3)
            {
                return BadRequest("Invalid email");
            }
            if (userInfo.Password == null || userInfo.Password.Length < 4)
            {
                return BadRequest("Password must be at least 4 characters long");
            }
            userInfo.CreatedAt = DateTime.Now;
            userInfo.Password = PasswordUtils.ComputeSha256Hash(userInfo.Password);
            _context.UsersItems.Add(userInfo);

            await _context.SaveChangesAsync();
            
            return Ok();
        }


         private async Task<UserInfo> GetUser(string email, string password)
        {
            return await _context.UsersItems.FirstOrDefaultAsync(u => u.Email == email && 
                u.Password == password);
        }
    }

}

