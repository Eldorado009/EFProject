using Domain.Entities;
using EFProject.Controllers;
using System.Linq.Expressions;

//CategoryController categoryController = new CategoryController();
//await categoryController.DeleteAsync();

ProductController productController = new ProductController();
await productController.SearchByColorAsync();