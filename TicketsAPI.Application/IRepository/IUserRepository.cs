using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Domain;

namespace TicketsAPI.Application.IRepository
{
    public interface IUserRepository
    {
        Task<string> CreateUser(User model);
        Task<User> FindByName(string name);
    }
}
