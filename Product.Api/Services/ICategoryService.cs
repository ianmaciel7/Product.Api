using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface ICategoryService
    {
        GetCategoriesOutputModel Get(GetCategoriesInputModel inputModel);
    }
}