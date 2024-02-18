using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI.Domain
{
    public class Ticket
    {
        public long Id { get; set; }
        public string Proveedor  { get; set; } = string.Empty;
        public decimal Monto  { get; set; }
        public string Moneda { get; set; } = string.Empty;
        public DateTime Fecha  { get; set; }
        public string? Comentario  { get; set; }
        public Guid UsuarioCreoId  { get; set; }
        public DateTime FechaCreo { get; set; }
        public Guid? UsuarioModificoId { get; set; }
        public DateTime? FechaModifico { get; set; }
    }
}
