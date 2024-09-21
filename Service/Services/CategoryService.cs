using Domain.Entities;
using Microsoft.Extensions.Caching.Memory;
using Repository.Repositories;
using Repository.Repositories.Intefaces;
using Service.Services.Intefaces;
using System.Linq.Expressions;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryService()
        {
            _categoryRepo = new CategoryRepository();
        }
        public async Task CreateAsync(Category category)
        {
            await _categoryRepo.CreateAsync(category);
        }

        public async Task DeletedAsync(int id)
        {
            await _categoryRepo.GetByIdAsync(id);
            await _categoryRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Category>> GetAllWithProductsAsync(Expression<Func<Category, bool>> expression)
        {
            return await _categoryRepo.GetAllWithProductsAsync(expression);
        }

        public async Task<IEnumerable<Category>> GetArchiveCategories()
        {
            return await _categoryRepo.GetArchiveCategories();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> SearchAsync(string searchText)
        {
            return await _categoryRepo.SearchAsync(searchText);
        }

        public async Task<IEnumerable<Category>> SortWithCreatedDate(DateTime date)
        {
            return await _categoryRepo.SortWithCreatedDate(date);
        }

        public async Task UpdateAsync(Category category)
        {
            var existName = await _categoryRepo.GetByIdAsync(category.Id);
            existName.Name = category.Name;
            await _categoryRepo.UpdateAsync(existName);
        }
    }
}
