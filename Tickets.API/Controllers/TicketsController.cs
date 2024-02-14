using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;

namespace Tickets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<List<Ticket>> GetAll()
        {
            var tickets = _ticketService.GetAllTickets();
            return await tickets;
        }

        [HttpGet("{id}")]
        public async Task<Ticket> GetById(int id)
        {
            return await _ticketService.GetTicket(id);
        }

        [HttpPost]
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            return await _ticketService.CreateTicket(ticket);
        }

        [HttpPut]
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketService.UpdateTicket(ticket);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTicket(int id)
        {
            await _ticketService.DeleteTicket(id);
        }
    }
}
