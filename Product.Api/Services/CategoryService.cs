using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper,ICategoryRepository categoryRepository) : ICategoryService
    {
        public FindAllCategoriesOutputModel FindAll(FindAllCategoriesInputModel inputModel)
        {
            var categories = categoryRepository.FindAll(inputModel);
            return mapper.Map<FindAllCategoriesOutputModel>(categories, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }

        public FindCategoryOutputModel Find(FindCategoryInputModel inputModel)
        {
            var category = categoryRepository.FindAll(inputModel);
            return mapper.Map<FindCategoryOutputModel>(category, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}