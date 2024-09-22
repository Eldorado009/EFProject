using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Intefaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product);
        Task DeletedAsync(int id);
        Task UpdateAsync(Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> SearchByNameAsync(string searchName);
        Task<IEnumerable<Product>> FilterByCategoryNameAsync(string categoryName);
        Task<IEnumerable<Product>> GetAllWithCategoryIdAsync(int id);
        Task<IEnumerable<Product>> SortWithPriceAsync(decimal? maxPrice = null);
        Task<IEnumerable<Product>> SortByCreatedDateAsync(DateTime date);
        Task<IEnumerable<Product>> SearchByColorAsync(string searchText);
    }
}
