using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Domain;

namespace TicketsAPI.Infrastructure
{
    public class TicketsDBContext : DbContext
    {
        public TicketsDBContext(DbContextOptions<TicketsDBContext> options) : base(options)
        {

        }

        public DbSet<Ticket> Recibos { get; set; }
    }
}
