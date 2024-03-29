﻿using TicketsAPI.Application.IRepository;
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

        public async Task<Ticket> UpdateTicket(Ticket ticket, Guid userId)
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
                existingTicket.UsuarioModificoId = userId;
            }
            else
                throw new Exception("No hay registro por actualizar");

            return await _ticketRepository.UpdateTicket(existingTicket);
        }

        public async Task<Ticket> CreateTicket(Ticket ticket, Guid userId)
        {
            var newTicket = new Ticket()
            {
                Monto = ticket.Monto,
                Moneda = ticket.Moneda,
                Proveedor = ticket.Proveedor,
                Comentario = ticket.Comentario,
                Fecha = ticket.Fecha,
                FechaCreo = DateTime.Now,
                UsuarioCreoId = userId,
            };
            return await _ticketRepository.CreateTicket(newTicket);
        }

        public async Task<List<Ticket>> GetAllTickets(Guid userId, DateTime? fromDate = null)
        {
            return await _ticketRepository.GetAllTickets(userId, fromDate);
        }

        public async Task<Ticket> GetTicket(long id)
        {
            return await _ticketRepository.GetTicket(id);
        }
    }
}
