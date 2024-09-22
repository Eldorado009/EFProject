using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Intefaces;

namespace Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository()
        {
            _context = new AppDbContext();
            _dbSet = _context.Set<Product>();
        }
        public async Task<IEnumerable<Product>> FilterByCategoryName(string categoryName)
        {
            return await _dbSet.Where(x=>x.Name.ToLower()
                               .Contains(categoryName.ToLower().Trim()))
                               .ToListAsync();   
        }

        public async Task<IEnumerable<Product>> GetAllWithCategoryId(int id)
        {
            return await _dbSet.Where(x=>x.CategoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByColor(string searchText)
        {
            return await _dbSet.Where(x => x.Color.ToLower()
                               .Contains(searchText.ToLower().Trim()))
                               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string searchName)
        {
            return await _dbSet.Where(x => x.Name.ToLower()
                               .Contains(searchName.ToLower().Trim()))
                               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortByCreatedDate(DateTime date)
        {
            return await _dbSet.Where(x => x.CreatedDate >= date)
                               .OrderBy(x => x.CreatedDate)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SortWithPrice(decimal? maxPrice = null)
        {
            if (maxPrice == null)
            {
                return await _dbSet.OrderBy(x => x.Price).ToListAsync();
            }
            return await _dbSet.Where(x=>x.Price<=maxPrice).OrderBy(x=>x.Price).ToListAsync();
        }
    }
}
