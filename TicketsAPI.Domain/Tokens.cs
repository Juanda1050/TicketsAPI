﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAPI.Domain
{
    public class Tokens
    {
        public string Token { get; set; } = string.Empty; 
        public string RefreshToken { get; set; } = string.Empty;
    }
}
