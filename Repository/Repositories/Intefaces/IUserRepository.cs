using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Intefaces
{
    public interface IUserRepository
    {
        Task<User> CheckAsync(string username, string password);
        Task RegisterAsync(User user);
    }
}
