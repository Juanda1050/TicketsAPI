using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Application.IRepository;
using TicketsAPI.Domain;

namespace TicketsAPI.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketsDBContext _dbContext;

        public UserRepository(TicketsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateUser(User model)
        {
            try
            {
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error al crear el usuario");
                return false;
            }
        }

    }
}
