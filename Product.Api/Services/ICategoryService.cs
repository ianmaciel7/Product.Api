using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;

namespace Product.Api.Services
{
    public interface ICategoryService : IService<Category>
    {
        IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel);
        IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel);
        IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel);
        IRemoveCategoryOuputModel Remove(IRemoveCategoryInputModel inputModel);
        IUpdateCategoryOutputModel Update(IUpdateCategoryInputModel inputModel);
    }
}