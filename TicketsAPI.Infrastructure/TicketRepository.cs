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
        public List<Tickets> GetAllTickets()
        {
            throw new NotImplementedException();
        }
    }
}
