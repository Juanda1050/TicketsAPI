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

        public Ticket CreateTicket(Ticket ticket)
        {
            _ticketDBContext.Add(ticket);
            _ticketDBContext.SaveChanges();

            return ticket;
        }

        public List<Ticket> GetAllTickets()
        {
            return _ticketDBContext.Recibos.ToList();
        }
    }
}
