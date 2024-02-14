﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
        public DateTime FechaCreo { get; set; }
    }
}
