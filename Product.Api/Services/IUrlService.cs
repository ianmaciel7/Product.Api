using Product.Api.Dtos;

namespace Product.Api.Services
{
    public interface IUrlService
    {
        Uri GetAllCategoriesUri(FindAllCategoriesInputModel inputModel);
        Uri GetAllProductsUri(FindAllProductsInputModel inputModel);
        Uri GetCategoryUri(FindCategoryInputModel inputModel);
        Uri GetProductUri(FindAllProductsInputModel inputModel);
    }
}