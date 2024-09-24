using AutoMapper;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
    {
        public IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel)
        {
            var categories = categoryRepository.FindAllById(inputModel?.CategoryId);
            return mapper.Map<FindAllCategoriesOutputModel>(categories, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel)
        {
            var category = categoryRepository.FindById(inputModel.CategoryId);
            return mapper.Map<FindCategoryOutputModel>(category, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel)
        {
            var category = mapper.Map<Category>(inputModel);
            categoryRepository.Add(category);
            categoryRepository.SaveChanges();
            return mapper.Map<FindCategoryOutputModel>(category, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}