using Domain.Entities;
using System.Linq.Expressions;

namespace Repository.Repositories.Intefaces
{
    public interface ICategoryRepository<T> : IBaseRepository<Category> 
    {
        Task<IEnumerable<T>> GetAllWithProductsAsync(Expression<Func<T,bool>> expression);
        Task<IEnumerable<T>> SearchAsync(string searchText);
        Task<IEnumerable<T>> SortWithCreatedDate(DateTime date);
        Task<IEnumerable<T>> GetArchiveCategories();

    }
}
