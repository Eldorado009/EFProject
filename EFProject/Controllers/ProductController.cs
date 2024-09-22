using Service.Services.Intefaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using EFProject.Helpers.Exceptions;
using Repository.Data;

namespace EFProject.Controllers
{
    public class ProductController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
        }

        public async Task CreateAsync()
        {
            Console.WriteLine("Add Product name:");
            CreateProduct: string name = Console.ReadLine();
            
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CreateProduct;
                }
                else if (string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CreateProduct;
                }
                else if (name.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CreateProduct;
                }
                Console.WriteLine("Add Count:");
            CountProduct: string countProduct = Console.ReadLine();
                bool isCorrectFormat = int.TryParse(countProduct, out int count);
                if (countProduct == null)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CountProduct;
                }
                else if (string.IsNullOrWhiteSpace(countProduct))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CountProduct;
                }
                else if (string.IsNullOrEmpty(countProduct))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CountProduct;
                }
                else if (count<= 0)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto CountProduct;
                }
                Console.WriteLine("Add Price:");
                PriceProduct: string priceProduct = Console.ReadLine();
                bool isCorrectFormat1 = int.TryParse(priceProduct, out int price);
                if (priceProduct == null)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto PriceProduct;
                }
                else if (string.IsNullOrWhiteSpace(priceProduct))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto PriceProduct;
                }
                else if (string.IsNullOrEmpty(priceProduct))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto PriceProduct;
                }
                else if (price <= 0)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto PriceProduct;
                }
                Console.WriteLine("Add Description:");
                DescriptionProduct: string description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DescriptionProduct;
                }
                else if (string.IsNullOrEmpty(description))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DescriptionProduct;
                }
                else if (description.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DescriptionProduct;
                }
                else if (description.Length <= 0 || description.Length >= 200)
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto DescriptionProduct;
                }
                Console.WriteLine("Add Color:");
                ColorProduct: string color = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(color))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto ColorProduct;
                }
                else if (color.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto ColorProduct;
                }
                else if (color.Length >= 20 || color.Length <= 0 )
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto ColorProduct;
                }
                Console.WriteLine("Add Category Id:");
            CategoryIdProduct: string idStr = Console.ReadLine();
                bool IsCorrectFormat = int.TryParse(idStr, out int id);
                var data = await _categoryService.GetByIdAsync(id);
                if (data == null)
                {
                    Console.WriteLine("Data not found! Please try again:");
                    goto CategoryIdProduct;
                }

                await _productService.CreateAsync(new Product { Name = name, Count = count, Price = price, Description =description, Color = color, CategoryId = id});
            
        }

        public async Task DeleteAsync()
        {
            Console.WriteLine("Add product Id:");
        DeletedProduct: string idStr = Console.ReadLine();
            bool IsCorrectFormat = int.TryParse(idStr, out int id);
            var data = await _productService.GetByIdAsync(id);
            if (data == null)
            {
                Console.WriteLine("Data not found! Please try again:");
                goto DeletedProduct;
            }
            if (string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto DeletedProduct;
            }
            if (string.IsNullOrEmpty(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto DeletedProduct;
            }
            else
            {
                await _productService.DeletedAsync(id);
            }
        }

        public async Task UpdateAsync()
        {
            Console.WriteLine("Add category Id:");
        UpdateProduct: string idStr = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(idStr, out int id);
            if (!isCorrectFormat || string.IsNullOrWhiteSpace(idStr))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProduct;
            }
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                Console.WriteLine("Product Not Found. Please try again:");
                goto UpdateProduct;
            }
            Console.WriteLine($"Id:{product.Id}, Name:{product.Name}, Count: {product.Count}, Price: {product.Price}, Description: {product.Description}, Color: {product.Color}, Category Id{product.CategoryId}");
            Console.WriteLine("Please old Product name:");
        UpdateOldProduct: string OldName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(OldName) || OldName != product.Name)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateOldProduct;
            }
            Console.WriteLine("Add new Product name:");

        UpdateProductName: string newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName) || newName.Any(char.IsDigit) || newName == product.Name)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductName;
            }
            product.Name = newName;
            Console.WriteLine("Product new Count:");
            UpdateProductCount: string newCount = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newCount)) 
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductCount;
            }
            else
            {
                if (int.TryParse(newCount,out int counts))
                {
                    if (counts == product.Count)
                    {
                        Console.WriteLine("New count old count is the same. Please try again:");
                        goto UpdateProductCount;
                    }
                    else
                    {
                        if (counts <= 0)
                        {
                            Console.WriteLine("Invalid input. Please try again:");
                            goto UpdateProductCount;
                        }
                        else
                        {
                            product.Count = counts;
                            Console.WriteLine($"Product Updated to: {product.Count}");
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto UpdateProductCount;
                }
            }
            Console.WriteLine("Product new Price:");
        UpdateProductPrice: string newPrice = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newPrice))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductPrice;
            }
            else
            {
                if (int.TryParse(newPrice, out int prices))
                {
                    if (prices == product.Price)
                    {
                        Console.WriteLine("New price old price is the same. Please try again:");
                        goto UpdateProductPrice;
                    }
                    else
                    {
                        if (prices <= 0)
                        {
                            Console.WriteLine("Invalid input. Please try again:");
                            goto UpdateProductPrice;
                        }
                        else
                        {
                            product.Price = prices;
                            Console.WriteLine($"Product Updated to: {product.Price}");
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again:");
                    goto UpdateProductPrice;
                }
            }
            Console.WriteLine("Product new Description:");

        UpdateProductDescription: string newDescription = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDescription) || newDescription.Any(char.IsDigit) || newDescription == product.Description)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductDescription;
            }
            Console.WriteLine("Product new Color:");

        UpdateProductColor: string newColor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newColor) || newColor.Any(char.IsDigit) || newColor == product.Color)
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductColor;
            }

            Console.WriteLine("Product new Category Id:");

        UpdateProductCategoryId: string newCategoryId = Console.ReadLine();
            bool isCorrectFormat3 = int.TryParse(newCategoryId, out int categoryId);
            if (!isCorrectFormat3 || string.IsNullOrWhiteSpace(newCategoryId))
            {
                Console.WriteLine("Invalid input. Please try again:");
                goto UpdateProductCategoryId;
            }
            await _productService.GetByIdAsync(id);
            if (product == null)
            {
                Console.WriteLine("Product Not Found. Please try again:");
                goto UpdateProduct;
            }
            await _productService.UpdateAsync(product);
            Console.WriteLine($"Updated succesful: {product.Name},{product.Count},{product.Price},{product.Description},{product.Color},{product.CategoryId}");
        }
    }
    
}
