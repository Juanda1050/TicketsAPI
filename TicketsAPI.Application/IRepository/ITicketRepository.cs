using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Domain;

namespace TicketsAPI.Application.IRepository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicket(long id);
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task DeleteTicket(long id);
    }
}
