using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Domain;

namespace TicketsAPI.Application.IService
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        Ticket CreateTicket(Ticket ticket);
    }
}
