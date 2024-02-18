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
        Task<List<Ticket>> GetAllTickets(DateTime? fromDate = null);
        Task<Ticket> GetTicket(long id);
        Task<Ticket> CreateTicket(Ticket ticket, Guid userId);
        Task<Ticket> UpdateTicket(Ticket ticket, Guid userId);
        Task DeleteTicket(long id);
    }
}
