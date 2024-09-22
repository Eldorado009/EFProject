using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Intefaces;
using Service.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        public UserService()
        {
            _userRepo = new UserRepository();
        }
        public async Task<User> CheckAsync(string username, string password)
        {
            return await _userRepo.CheckAsync(username, password);
        }

        public async Task RegisterAsync(User user)
        {
            await _userRepo.RegisterAsync(user);
        }
    }
}
