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

        public async Task DeleteTicket(int id)
        {
            var ticket = await _ticketDBContext.Recibos.FindAsync(id);

            if (ticket != null)
            {
                _ticketDBContext.Recibos.Remove(ticket);
                await _ticketDBContext.SaveChangesAsync();
            }
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            var existingTicket = await _ticketDBContext.Recibos.FindAsync(ticket.Id);

            if (existingTicket == null)
            {
                throw new ArgumentException("No se pudo encontrar el recibo especificado.");
            }

            _ticketDBContext.Update(ticket);
            await _ticketDBContext.SaveChangesAsync();

            return existingTicket;
        }

        public async Task<Ticket> CreateTicket(Ticket ticket)
        {
            _ticketDBContext.Add(ticket);
            await _ticketDBContext.SaveChangesAsync();

            return ticket;
        }

        public async Task<List<Ticket>> GetAllTickets()
        {
            return await _ticketDBContext.Recibos.ToListAsync();
        }

        public async Task<Ticket> GetTicket(int id)
        {
            var ticket = await _ticketDBContext.Recibos.FindAsync(id);

            if(ticket == null)
                throw new ArgumentException("No se pudo encontrar el recibo especificado.");

            return ticket;
        }
    }
}
