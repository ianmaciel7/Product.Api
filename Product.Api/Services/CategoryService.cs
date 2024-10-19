using AutoMapper;
using Product.Api.Data.Entities;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper, ICategoryRepository categoryRepository)
        : Service<Category,CategoryId>(urlService, categoryRepository, mapper),
        ICategoryService
    {

        public IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel)
        {
            return FindById<IFindCategoryOutputModel>(inputModel.CategoryId);
        }

        public IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel)
        {           
            return FindAllById<IFindAllCategoriesOutputModel>(inputModel.CategoryId);
        }

        public IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel)
        {
            return base.Add<IAddCategoryOutputModel>(inputModel);
        }

        public IRemoveCategoryOuputModel Remove(IRemoveCategoryInputModel inputModel)
        {
            return base.RemoveById<IRemoveCategoryOuputModel>(inputModel.CategoryId);
        }

        public IUpdateCategoryOutputModel Update(IUpdateCategoryInputModel inputModel)
        {
            return base.Update<IUpdateCategoryOutputModel>(inputModel);
        }
    }
}