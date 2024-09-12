using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface ICategoryService
    {
        GetCategoryOutputModel Get(GetCategoryInputModel inputModel);
    }
}