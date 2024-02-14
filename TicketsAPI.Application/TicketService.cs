using TicketsAPI.Application.IRepository;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;

namespace TicketsAPI.Application
{
    public class TicketService : ITicketService
    {
        public readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task DeleteTicket(int id)
        {
            await _ticketRepository.DeleteTicket(id);
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketRepository.UpdateTicket(ticket);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            return await _ticketRepository.CreateTicket(ticket);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _ticketRepository.GetAllTickets();
        }

        public async Task<Ticket> GetTicket(int id)
        {
            return await _ticketRepository.GetTicket(id);
        }
    }
}
