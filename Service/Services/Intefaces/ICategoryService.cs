using Domain.Entities;
using System.Linq.Expressions;

namespace Service.Services.Intefaces
{
    public interface ICategoryService
    {
        Task CreateAsync(Category category);
        Task DeletedAsync(int id);
        Task UpdateAsync(Category category);
        Task <Category> GetByIdAsync(int id);
        Task <IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetAllWithProductsAsync(Expression<Func<Category, bool>> expression);
        Task<IEnumerable<Category>> SearchAsync(string searchText);
        Task<IEnumerable<Category>> SortWithCreatedDateAsync(DateTime date);
        Task<Tuple<IEnumerable<Category>, IEnumerable<ArchiveCategory>>> GetArchiveCategoriesAsync();
    }
}
