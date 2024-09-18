using Domain.Entities;
using System.Linq.Expressions;

namespace Service.Services.Intefaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task DeletedAsync(int id);
        Task UpdateAsync(int id, Category category);
        Task <Category> GetByIdAsync(int id);
        Task <IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetAllWithProductsAsync(Expression<Func<Category, bool>> expression);
        Task<IEnumerable<Category>> SearchAsync(string searchText);
        Task<IEnumerable<Category>> SortWithCreatedDate(DateTime date);
        Task<IEnumerable<Category>> GetArchiveCategories();
    }
}
