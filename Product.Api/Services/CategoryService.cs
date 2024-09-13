using AutoMapper;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class CategoryService(IMapper mapper,ICategoryRepository categoryRepository) : ICategoryService
    {
        public GetCategoryOutputModel Get(GetCategoryInputModel inputModel)
        {
            var categories = categoryRepository.Get(inputModel).ToList();
            return mapper.Map<GetCategoryOutputModel>(categories);
        }
    }
}