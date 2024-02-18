using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;

namespace Tickets.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        //[Authorize]
        [HttpGet]
        public async Task<List<Ticket>> GetAll()
        {
            var tickets = _ticketService.GetAllTickets();
            return await tickets;
        }

        //[Authorize]
        [HttpGet("{id}")]
        public async Task<Ticket> GetById(long id)
        {
            return await _ticketService.GetTicket(id);
        }

        //[Authorize]
        [HttpPost]
        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            return await _ticketService.CreateTicket(ticket);
        }

        //[Authorize]
        [HttpPut]
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketService.UpdateTicket(ticket);
        }

        //[Authorize]
        [HttpDelete("{id}")]
        public async Task DeleteTicket(long id)
        {
            await _ticketService.DeleteTicket(id);
        }
    }
}
