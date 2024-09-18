using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Intefaces
{
    public interface ICategoryRepository<T> : IBaseRepository<Category> 
    {
        Task<IEnumerable<T>> GetAllWithProductsAsync(Expression<Func<T,bool>> expression);
    }
}
