using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Application.IRepository;
using TicketsAPI.Domain;

namespace TicketsAPI.Infrastructure
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketsDBContext _ticketDBContext;

        public TicketRepository(TicketsDBContext ticketDBContext)
        {
            _ticketDBContext = ticketDBContext;
        }

        public async Task DeleteTicket(long id)
        {
            var ticket = await _ticketDBContext.Recibos.FirstOrDefaultAsync(x => x.Id == id);

            if (ticket != null)
            {
                _ticketDBContext.Recibos.Remove(ticket);
                await _ticketDBContext.SaveChangesAsync();
            }
            else
                throw new Exception($"El recibo No.{id} no existe");
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            _ticketDBContext.Update(ticket);
            await _ticketDBContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            _ticketDBContext.Add(ticket);
            await _ticketDBContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<List<Ticket>> GetAllTickets(Guid userId, DateTime? fromDate = null)
        {
            var query = _ticketDBContext.Recibos.Where(x => x.UsuarioCreoId == userId);

            if (fromDate.HasValue && fromDate != DateTime.MinValue)
                query = query.Where(ticket => ticket.Fecha.Date == fromDate.Value.Date);

            return await query.ToListAsync();
        }


        public async Task<Ticket> GetTicket(long id)
        {
            var ticket = await _ticketDBContext.Recibos.FirstOrDefaultAsync(x => x.Id == id);

            if (ticket == null)
                throw new ArgumentException("No se pudo encontrar el recibo especificado.");

            return ticket;
        }
    }
}
