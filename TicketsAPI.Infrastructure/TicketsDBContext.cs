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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Nombre = "admin", Contraseña = "12345678", FechaCreo = DateTime.Now });
        //}

        public DbSet<Ticket> Recibos { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }
}
