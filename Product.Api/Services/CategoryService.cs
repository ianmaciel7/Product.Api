using AutoMapper;
using CommunityToolkit.Diagnostics;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper, ICategoryRepository categoryRepository)
        : Service<Category>(urlService, categoryRepository, mapper),
        ICategoryService
    {

        public IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel)
        {
            return FindById<FindCategoryOutputModel>(inputModel.CategoryId);
        }

        public IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel)
        {           
            return FindAllById<FindAllCategoriesOutputModel>(inputModel.CategoryId);
        }

        public IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel)
        {
            return base.Add<FindCategoryOutputModel>(inputModel);
        }

        public IRemoveCategoryOuputModel Remove(IRemoveCategoryInputModel inputModel)
        {
            return base.RemoveById<RemoveCategoryOuputModel>(inputModel.CategoryId);
        }
    }
}