using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.IRepository;
using TicketsAPI.Domain;

namespace Tickets.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ITokensRepository _tokenRepository;

        public UsersController(ITokensRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public List<string> Get()
        {
            var recruits = new List<string>
        {
            "John Doe",
            "Jane Doe",
            "Junior Doe"
        };

            return recruits;
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
