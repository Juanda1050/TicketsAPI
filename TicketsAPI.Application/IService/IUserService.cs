﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Domain;

namespace TicketsAPI.Application.IService
{
    public interface IUserService
    {
        Task<bool> CreateUser(Login model);
    }
}
