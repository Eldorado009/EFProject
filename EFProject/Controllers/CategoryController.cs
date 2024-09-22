using Domain.Entities;
using EFProject.Helpers.Exceptions;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Service.Services;
using Service.Services.Intefaces;
using System.Linq.Expressions;

namespace EFProject.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }

        public async Task CreateAsync()
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

        public async Task DeleteAsync()
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
        public async Task UpdateAsync()
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

        public async Task GetByIdAsync()
        {
            Console.WriteLine("Add category Id:");
            IdCategory: string idStr = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(idStr, out int id);
            if (!isCorrectFormat || string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto IdCategory;
            }
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                Console.WriteLine("Category Id Not Found. Please try again:");
                goto IdCategory;
            }
            Console.WriteLine($"Id:{category.Id}, Name:{category.Name}");
        }

        public async Task GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            Console.WriteLine("Categories Table:");
            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
            }
            
        }

        public async Task GetAllWithProductsAsync()
        {
            Console.WriteLine("Add Category name:");
            NameCategory: string name = Console.ReadLine();
            Expression<Func<Category, bool>> expression = c => c.Name == name;
            var categories = await _categoryService.GetAllWithProductsAsync(expression);        
            if (categories == null || !categories.Any())
            {
                Console.WriteLine("Categories Not Found! Please try again:");
                goto NameCategory;
            }
            else
            {
                bool ProductsCategory = false;
                Console.WriteLine("Categories With Products:");
                foreach (var category in categories)
                {
                    if (category.Products != null && category.Products.Any())
                    {
                        ProductsCategory = true;
                        Console.WriteLine($"Id:{category.Id}, Name: {category.Name}");
                        Console.WriteLine("Products:");
                        foreach (var product in category.Products)
                        {
                            Console.WriteLine($"Id:{product.Id}, Name: {product.Name}, Price: {product.Price}, Desc: {product.Description}, Color: {product.Color}, Created Date: {product.CreatedDate}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Products for this category");
                    }
                }
                if (ProductsCategory)
                {
                    Console.WriteLine("Products Not Found");
                }
            }
        }

        public async Task SearchAsync()
        {
            Console.WriteLine("Add Category Name:");
            searchCategory: string searchText = Console.ReadLine();
            var categories = await _categoryService.SearchAsync(searchText);
            if (categories == null || !categories.Any())
            {
                Console.WriteLine("Categories Not Found! Please try again:");
                goto searchCategory;
            }
            else if (string.IsNullOrEmpty(searchText))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto searchCategory;
            }
            else if (string.IsNullOrWhiteSpace(searchText))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto searchCategory;
            }
            else
            {
                Console.WriteLine("Categories:");
                foreach (var category in categories)
                {
                    Console.WriteLine($"Id:{category.Id}, Name: {category.Name}");
                }
            }
        }

        public async Task SortWithCreatedDate()
        {
            var categoryDate = await _categoryService.SortWithCreatedDateAsync(DateTime.MinValue);
            if (categoryDate == null)
            {
                Console.WriteLine("Category Not Found");
            }
            else
            {
                Console.WriteLine("Category Sort by oldest to newest:");
                foreach (var category in categoryDate.OrderBy(x=>x.CreatedDate))
                {
                    Console.WriteLine($"Id:{category.Id},Name:{category.Name},Created Date:{category.CreatedDate}");
                }
            }
        }


        public async Task GetArchiveCategoriesAsync()
        {
            var result = await _categoryService.GetArchiveCategoriesAsync();
            var categories = result.Item1;
            var archiveCategories = result.Item2;
            Console.WriteLine("Categories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"Id: {category.Id}, Name: {category.Name}, Created Date: {category.CreatedDate}");
            }
            Console.WriteLine("Archive Categories:");
            foreach(var archiveCategory in archiveCategories)
            {
                Console.WriteLine($"Id:{archiveCategory.Id}, Name: {archiveCategory}, Created Date:{archiveCategory.CreatedDate}, Deleted Date: {archiveCategory.DeletedDate}");
            }
        }
    }
}
