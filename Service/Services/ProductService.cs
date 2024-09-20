using Domain.Entities;
using Repository.Repositories;
using Repository.Repositories.Intefaces;
using Service.Services.Intefaces;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService()
        {
            _productRepo = new ProductRepository();
        }
        public async Task CreateAsync(Product product)
        {
            await _productRepo.CreateAsync(product);
        }

        public async Task DeletedAsync(int id)
        {
            await _productRepo.GetByIdAsync(id);
            await _productRepo.DeleteAsync(id);
        }

        public async Task<IEnumerable<Product>> FilterByCategoryName(string categoryName)
        {
            return await _productRepo.FilterByCategoryName(categoryName);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepo.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryId(int id)
        {
            return await _productRepo.GetAllWithCategoryId(id);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> SearchByColor(string searchText)
        {
            return await _productRepo.SearchByColor(searchText);
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string searchName)
        {
            return await _productRepo.SearchByNameAsync(searchName);
        }

        public async Task<IEnumerable<Product>> SortByCreatedDate(DateTime date)
        {
            return await _productRepo.SortByCreatedDate(date);
        }

        public async Task<IEnumerable<Product>> SortWithPrice(decimal price)
        {
            return await _productRepo.SortWithPrice(price);
        }

        public async Task UpdateAsync(int id, Product product)
        {
            var existProduct = await _productRepo.GetByIdAsync(id);
            existProduct.Name = product.Name;
            await _productRepo.UpdateAsync(existProduct);
        }
    }
}
