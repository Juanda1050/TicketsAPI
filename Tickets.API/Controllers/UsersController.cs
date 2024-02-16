using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketsAPI.Application.IRepository;
using TicketsAPI.Domain;
using TicketsAPI.Infrastructure;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Tickets.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly TicketsDBContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ITokensRepository _tokenRepository;

        public UsersController(TicketsDBContext dBContext, ITokensRepository tokenRepository, IConfiguration configuration)
        {
            _dbContext = dBContext;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Nombre == model.Nombre && x.Contraseña == model.Contraseña);
            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signingCredentials
            );

            return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User users)
        {
            var token = _tokenRepository.Authenticate(users);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
