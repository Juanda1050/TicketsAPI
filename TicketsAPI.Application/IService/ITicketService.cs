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
        Task<List<Ticket>> GetAllTickets();
        Task<Ticket> GetTicket(int id);
        Task<Ticket> CreateTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task DeleteTicket(int id);
    }
}
