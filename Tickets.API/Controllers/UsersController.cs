using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketsAPI.Application;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;
using TicketsAPI.Infrastructure;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly TicketsDBContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UsersController(TicketsDBContext dBContext, IConfiguration configuration, IUserService userService)
        {
            _dbContext = dBContext;
            _configuration = configuration;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ResponseObject>> Register(Login model)
        {
            try
            {
                var message = await _userService.CreateUser(model);
                return Ok(new ResponseObject { Message = message, IsError = false });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseObject { Message = ex.Message, IsError = true });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ResponseToken>> Login(Login model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Nombre == model.Nombre);
            if (user == null || !Utils.VerifyPassword(model.Contraseña, user.Contraseña))
                return Unauthorized();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("usuarioId", user.Id.ToString())
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

            return Ok(new ResponseToken { Token = new JwtSecurityTokenHandler().WriteToken(token), UsuarioId = user.Id });
        }
    }
}
