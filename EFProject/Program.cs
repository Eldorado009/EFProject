
using Domain.Entities;
using EFProject.Controllers;
using EFProject.Helpers.Enum;
UserController userController = new UserController();
bool isLoggedIn = false;
while (!isLoggedIn)
{
    Console.WriteLine("Please Login:");
    Console.WriteLine("Press to 1 enter");
    string? option = Console.ReadLine();
    int optionNumber;

    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        switch (optionNumber)
        {
            case 1:
                await userController.StartAsync();
                isLoggedIn = true; 
                break;
            default:
                Console.WriteLine("Please enter a valid option.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}
CategoryController categoryController = new CategoryController();
ProductController productController = new ProductController();

bool isContinue = true;
while (isContinue)
{
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - Create Category \n" +
                      "2 - Delete Category \n" +
                      "3 - Update Category \n" +
                      "4 - Get All Category \n" +
                      "5 - Get By Id Category\n" +

                      "------------------------\n" +

                      "6 - Get All With Products Category \n" +
                      "7 - Search Category \n" +
                      "8 - Sort With Created Date Category \n" +
                      "9 - Create Product \n" +
                      "10 - Delete Product \n" +

                      "-------------------------\n" +

                      "11 - Update Product \n" +
                      "12 - Get By Id Product  \n" +
                      "13 - Get All Product \n" +
                      "14 - Search By Name Product \n" +
                      "15 - Filter By Category Name Product \n" +

                      "-------------------------\n" +

                      "16 - Get All With Category Product  \n" +
                      "17 - Sort With Price Product \n" +
                      "18 - Sort By Created Date Product \n" +
                      "19 - Search By Color Product \n" +
                      "0 - Exit");



    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 20)
        {
            switch (optionNumber)
            {
                case(int)Menu.CreateCategory:
                    await categoryController.CreateAsync();
                    break;
                case(int)Menu.DeleteCategory:
                    await categoryController.DeleteAsync();
                    break;
                case(int)Menu.UpdateCategory:
                    await categoryController.UpdateAsync();
                    break;
                case(int)Menu.GetAllCategory:
                    await categoryController.GetAllAsync();
                    break;
                case(int)Menu.GetByIdCategory:
                    await categoryController.GetByIdAsync();
                    break;
                case(int)Menu.GetAllWithProductsCategory:
                    await categoryController.GetAllWithProductsAsync();
                    break;
                case (int)Menu.SearchCategory:
                    await categoryController.SearchAsync();
                    break;
                case (int)Menu.SortWithCreatedDateCategory:
                    await categoryController.SortWithCreatedDate();
                    break;
                case (int)Menu.CreateProduct:
                    await productController.CreateAsync();
                    break;
                case (int)Menu.DeleteProduct:
                    await productController.DeleteAsync();
                    break;
                case (int)Menu.UpdateProduct:
                    await productController.UpdateAsync();
                    break;
                case (int)Menu.GetByIdProduct:
                    await productController.GetByIdAsync();
                    break;
                case (int)Menu.GetAllProduct:
                    await productController.GetAllAsync();
                    break;
                case (int)Menu.SearchByNameProduct:
                    await productController.SearchByNameAsync();
                    break;
                case (int)Menu.FilterByCategoryNameProduct:
                    await productController.FilterByCategoryNameAsync();
                    break;
                case (int)Menu.GetAllWithCategoryProduct:
                    await productController.GetAllWithCategoryIdAsync();
                    break;
                case (int)Menu.SortWithPriceProduct:
                    await productController.SortWithPriceAsync();
                    break;
                case(int)Menu.SortByCreatedDateProduct:
                    await productController.SortByCreatedDateAsync();   
                    break;
                case (int)Menu.SearchByColorProduct:
                    await productController.SearchByColorAsync();
                    break;
                default:
                    isContinue = false;
                    break;
            }
        }
        else
        {
            Console.WriteLine("Please enter correct option number!!!");
        }
    }
    else
    {
        Console.WriteLine("Please enter correct format!!!");
    }
}
