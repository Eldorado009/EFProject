using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Repositories.Intefaces
{
    public interface ICategoryRepository : IBaseRepository<Category> 
    {
        Task<IEnumerable<Category>> GetAllWithProductsAsync(Expression<Func<Category,bool>> expression);
        Task<IEnumerable<Category>> SearchAsync(string searchText);
        Task<IEnumerable<Category>> SortWithCreatedDate(DateTime date);
        Task<IEnumerable<Category>> GetArchiveCategories();

    }
}
