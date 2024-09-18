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
        Task<IEnumerable<T>> FilterByCategoryName(string categoryName);
        Task<IEnumerable<T>> GetAllWithCategoryId(int id);
        Task<IEnumerable<T>> SortWithPrice(decimal price);
        Task<IEnumerable<T>> SortByCreatedDate(DateTime date);
        Task<IEnumerable<T>> SearchByColor(string searchText);
    }
}
