using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Intefaces
{
    public interface IUserService
    {
        Task<User> CheckAsync(string username, string password);
        Task RegisterAsync(User user);
    }
}
