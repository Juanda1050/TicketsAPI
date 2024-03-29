﻿using TicketsAPI.Application.IRepository;
using TicketsAPI.Application.IService;
using TicketsAPI.Domain;

namespace TicketsAPI.Application
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> CreateUser(Login model)
        {
            var existingUser = await _userRepository.FindByName(model.Nombre);

            if (existingUser != null)
                throw new Exception($"El usuario {existingUser.Nombre} ya existe");
            
            var hashPassword = Utils.HashPassword(model.Contraseña);
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                Nombre = model.Nombre,
                Contraseña = hashPassword,
                FechaCreo = DateTime.Now,
            };

            return await _userRepository.CreateUser(newUser);
        }
    }
}
