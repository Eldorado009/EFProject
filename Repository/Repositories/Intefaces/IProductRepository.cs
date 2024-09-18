using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Intefaces
{
    public interface IProductRepository<T> : IBaseRepository<Product>
    {
        Task<IEnumerable<T>> SearchByNameAsync(string searchName);
    }
}
