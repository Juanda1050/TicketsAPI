using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;

namespace Tickets.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Authorize]
        [HttpGet]
        public async Task<List<Ticket>> GetAll(DateTime? fromDate = null)
        {
            var tickets = await _ticketService.GetAllTickets(fromDate);
            return tickets;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Ticket> GetById(long id)
        {
            return await _ticketService.GetTicket(id);
        }

        [Authorize]
        [HttpPost]
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            var userClaim = User.FindFirst("usuarioId")?.Value;

            if (userClaim == null)
                throw new Exception("No existe una sesión activa");

            var userId = Guid.Parse(userClaim);

            return await _ticketService.CreateTicket(ticket, userId);
        }

        [Authorize]
        [HttpPut]
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            var userClaim = User.FindFirst("usuarioId")?.Value;

            if (userClaim == null)
                throw new Exception("No existe una sesión activa");

            var userId = Guid.Parse(userClaim);

            return await _ticketService.UpdateTicket(ticket, userId);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteTicket(long id)
        {
            await _ticketService.DeleteTicket(id);
        }
    }
}
