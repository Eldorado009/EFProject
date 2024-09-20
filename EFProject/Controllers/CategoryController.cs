using Service.Services;
using Service.Services.Intefaces;

namespace EFProject.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public void Create()
        {
            
        }
    }
}
