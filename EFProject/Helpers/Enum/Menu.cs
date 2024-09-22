using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Helpers.Enum
{
    public enum Menu
    {
        CreateCategory =1,
        DeleteCategory,
        UpdateCategory,
        GetAllCategory,
        GetByIdCategory,
        GetAllWithProductsCategory,
        SearchCategory,
        SortWithCreatedDateCategory,
        CreateProduct,
        DeleteProduct,
        UpdateProduct,
        GetByIdProduct,
        GetAllProduct,
        SearchByNameProduct,
        FilterByCategoryNameProduct,
        GetAllWithCategoryProduct,
        SortWithPriceProduct,
        SortByCreatedDateProduct,
        SearchByColorProduct
    }
}
