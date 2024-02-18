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
            {
                existingTicket.Monto = ticket.Monto;
                existingTicket.Moneda = ticket.Moneda;
                existingTicket.Proveedor = ticket.Proveedor;
                existingTicket.Comentario = ticket.Comentario;
                existingTicket.Fecha = ticket.Fecha;
                existingTicket.FechaModifico = DateTime.Now;
                existingTicket.UsuarioModificoId = Guid.Parse("2B00027F-AEEB-4781-B37C-2472AB5F8E73");
            }
            else
                throw new Exception("No hay registro por actualizar");

            return await _ticketRepository.UpdateTicket(existingTicket);
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
                UsuarioCreoId = Guid.Parse("2B00027F-AEEB-4781-B37C-2472AB5F8E73"),
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
