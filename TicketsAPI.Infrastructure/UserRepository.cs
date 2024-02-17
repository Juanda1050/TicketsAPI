using Microsoft.EntityFrameworkCore;
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

        public async Task<User> FindByName(string name)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Nombre == name);
        }

        public async Task<string> CreateUser(User model)
        {
            try
            {
                _dbContext.Add(model);
                await _dbContext.SaveChangesAsync();
                return "Usuario creado exitosamente";
            }
            catch (Exception)
            {
                return "Error al crear el usuario";
            }
        }

    }
}
