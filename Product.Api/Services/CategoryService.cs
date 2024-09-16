using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper,ICategoryRepository categoryRepository) : ICategoryService
    {
        public GetCategoriesOutputModel Get(GetCategoriesInputModel inputModel)
        {
            var categories = categoryRepository.Get(inputModel);
            return mapper.Map<GetCategoriesOutputModel>(categories, options =>
            {
                options.Items["urlService"] = urlService;
            });
        }
    }
}