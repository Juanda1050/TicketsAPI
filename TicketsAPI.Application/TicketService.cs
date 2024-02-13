﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Tickets> GetAllTickets()
        {
            var ticketList = _ticketRepository.GetAllTickets();
            return ticketList;
        }
    }
}