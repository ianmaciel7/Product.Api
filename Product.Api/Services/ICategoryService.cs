using Product.Api.Dtos;
using Product.Api.Dtos.Base;

namespace Product.Api.Services
{
    public interface ICategoryService
    {
        IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel);
        IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel);
        IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel);
        IRemoveCategoryOuputModel Remove(IRemoveCategoryInputModel inputModel);
    }
}