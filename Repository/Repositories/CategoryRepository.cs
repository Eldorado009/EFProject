using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Category> _dbSet;
        private readonly DbSet<ArchiveCategory> _archiveDbSet;
        public CategoryRepository()
        {
            _context = new AppDbContext();
            _dbSet = _context.Set<Category>();
            _archiveDbSet = _context.ArchiveCategories;
        }
        public async Task<IEnumerable<Category>> GetAllWithProductsAsync(Expression<Func<Category,bool>> expression)
        {
            return await _dbSet.Include(x=>x.Products).Where(expression).ToListAsync();
        }

        public async Task<Tuple<IEnumerable<Category>, IEnumerable<ArchiveCategory>>> GetArchiveCategoriesAsync()
        {
            var categories = await _dbSet.ToListAsync();
            var archiveCategories = await _archiveDbSet.ToListAsync();
            return new Tuple<IEnumerable<Category>, IEnumerable<ArchiveCategory>>(categories, archiveCategories);
        }

        public async Task<IEnumerable<Category>> SearchAsync(string searchText)
        {
            return await _dbSet.Where(x => x.Name.ToLower()
                                                 .Trim()
                                                 .Contains(searchText.ToLower()
                                                 .Trim()))
                                                 .ToListAsync();
        }

        public async Task<IEnumerable<Category>> SortWithCreatedDateAsync(DateTime date)
        {
            return await _dbSet.Where(x=>x.CreatedDate >= date)
                               .OrderBy(x=>x.CreatedDate)
                               .ToListAsync();
        }




    }
}
