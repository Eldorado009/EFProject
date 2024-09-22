using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Intefaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByNameAsync(string searchName);
        Task<IEnumerable<Product>> FilterByCategoryName(string categoryName);
        Task<IEnumerable<Product>> GetAllWithCategoryId(int id);
        Task<IEnumerable<Product>> SortWithPrice(decimal? maxPrice = null);
        Task<IEnumerable<Product>> SortByCreatedDate(DateTime date);
        Task<IEnumerable<Product>> SearchByColor(string searchText);
    }
}
