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

        public async Task DeleteTicket(long id)
        {
            await _ticketRepository.DeleteTicket(id);
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            var existingTicket = await _ticketRepository.GetTicket(ticket.Id);

            if (existingTicket != null)
                ticket = new Ticket()
                {
                    Id = existingTicket.Id,
                    Monto = ticket.Monto,
                    Moneda = ticket.Moneda,
                    Proveedor = ticket.Proveedor,
                    Comentario = ticket.Comentario,
                    Fecha = ticket.Fecha,
                    FechaCreo = existingTicket.FechaCreo,
                    UsuarioCreoId = existingTicket.UsuarioCreoId,
                    FechaModifico = DateTime.Now,
                    UsuarioModificoId = ticket.UsuarioCreoId,
                };

            return await _ticketRepository.UpdateTicket(ticket);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            var newTicket = new Ticket()
            {
                Monto = ticket.Monto,
                Moneda = ticket.Moneda,
                Proveedor = ticket.Proveedor,
                Comentario = ticket.Comentario,
                Fecha = ticket.Fecha,
                FechaCreo = DateTime.Now,
                UsuarioCreoId = ticket.UsuarioCreoId,
            };
            return await _ticketRepository.CreateTicket(newTicket);
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _ticketRepository.GetAllTickets();
        }

        public async Task<Ticket> GetTicket(long id)
        {
            return await _ticketRepository.GetTicket(id);
        }
    }
}
