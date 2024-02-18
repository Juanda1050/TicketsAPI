﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI.Domain
{
    public class ResponseObject
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
    }

    public class ResponseToken
    {
        public string Token { get; set; }
        public Guid UsuarioId { get; set; }
    }
}
