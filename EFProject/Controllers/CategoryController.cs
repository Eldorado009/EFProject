using Domain.Entities;
using EFProject.Helpers.Exceptions;
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

        public async Task Create()
        {
            Console.WriteLine("Add category name:");
            CreateCategory: string name=Console.ReadLine();
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CreateCategory;
                }
                else if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CreateCategory;
                }
                else if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Please try again:"); 
                    goto CreateCategory;
                }

                await _categoryService.CreateAsync(new Category { Name = name });
            }
            catch (Exception)
            {
                throw new NotFoundException();
            }
        }

        public async Task Delete()
        {
            Console.WriteLine("Add category Id:");
            DeletedCategory: string idStr = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(idStr, out int id);
            var data = await _categoryService.GetByIdAsync(id);
            if (data == null)
            {
                Console.WriteLine("Data not found! Please try again:");
                goto DeletedCategory;
            }
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto DeletedCategory;
            }
            if (string.IsNullOrEmpty(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto DeletedCategory;
            }
            else
            {
                await _categoryService.DeletedAsync(id);
            }
        }
        public async Task Update()
        {
            Console.WriteLine("Add category Id:");
            UpdateCategory: string idStr = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(idStr,out int id);
            if (!isCorrectFormat || string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateCategory;
            }
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                Console.WriteLine("Category Not Found. Please try again:");
                goto UpdateCategory;
            }
            Console.WriteLine($"Id:{category.Id}, Name:{category.Name}");
            Console.WriteLine("Please old Category name:");
            UpdateOldCategory: string OldName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(OldName)||OldName!=category.Name)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateOldCategory;
            }
            Console.WriteLine("Add new Category name:");
            
            UpdateCategoryName: string newName= Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName)|| newName.Any(char.IsDigit)||newName==category.Name)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateCategoryName;
            }
            category.Name = newName;
            await _categoryService.UpdateAsync(category);
            Console.WriteLine($"Updated succesful: {category.Name}");
        }
    }
}
