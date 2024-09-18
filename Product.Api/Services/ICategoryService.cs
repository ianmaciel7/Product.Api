using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface ICategoryService
    {
        FindAllCategoriesOutputModel GetAll(FindAllCategoriesInputModel inputModel);
        FindCategoryOutputModel Get(FindCategoryInputModel inputModel);
    }
}