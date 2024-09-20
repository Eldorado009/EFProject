using Domain.Entities;
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
                throw new Exception();
            }
        }

        public async Task Delete()
        {
            Console.WriteLine("Add category Id:");
        DeletedCategory: string idStr = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(idStr, out int id);
            try
            {
                if (string.IsNullOrWhiteSpace(idStr))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DeletedCategory;
                }
                else if (string.IsNullOrEmpty(idStr))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DeletedCategory;
                }
                else if (idStr.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DeletedCategory;
                }
                else
                {
                    await _categoryService.DeletedAsync(id);
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
