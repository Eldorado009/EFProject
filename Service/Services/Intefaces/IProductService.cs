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
        Task UpdateAsync(int id, Product product);
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> SearchByNameAsync(string searchName);
        Task<IEnumerable<Product>> FilterByCategoryName(string categoryName);
        Task<IEnumerable<Product>> GetAllWithCategoryId(int id);
        Task<IEnumerable<Product>> SortWithPrice(decimal price);
        Task<IEnumerable<Product>> SortByCreatedDate(DateTime date);
        Task<IEnumerable<Product>> SearchByColor(string searchText);
    }
}
