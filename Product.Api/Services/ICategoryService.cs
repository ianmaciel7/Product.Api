using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface ICategoryService
    {
        FindAllCategoriesOutputModel FindAll(FindAllCategoriesInputModel inputModel);
        FindCategoryOutputModel Find(FindCategoryInputModel inputModel);
    }
}