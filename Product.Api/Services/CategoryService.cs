using AutoMapper;
using CommunityToolkit.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Product.Api.Data.Entities;
using Product.Api.Dtos;
using Product.Api.Dtos.Base;
using Product.Api.Mappings.Extensions;
using Product.Api.Repositories;
using System;

namespace Product.Api.Services
{
    internal class CategoryService(IUrlService urlService, IMapper mapper, ICategoryRepository categoryRepository) : ICategoryService
    {
        public IFindAllCategoriesOutputModel FindAll(IFindAllCategoriesInputModel inputModel)
        {
            var categories = categoryRepository.FindAllById(inputModel?.CategoryId);
            return mapper.Map<FindAllCategoriesOutputModel>(categories, urlService);
        }

        public IFindCategoryOutputModel Find(IFindCategoryInputModel inputModel)
        {
            var category = categoryRepository.FindById(inputModel.CategoryId);
            Guard.IsNotNull(category);
            return mapper.Map<FindCategoryOutputModel>(category, urlService);
        }

        public IAddCategoryOutputModel Add(IAddCategoryInputModel inputModel)
        {
            var category = mapper.Map<Category>(inputModel);
            categoryRepository.Add(category);
            categoryRepository.SaveChanges();
            return mapper.Map<FindCategoryOutputModel>(category, urlService);
        }

        public IRemoveCategoryOuputModel Remove(IRemoveCategoryInputModel inputModel)
        {
            var category = categoryRepository.FindById(inputModel.CategoryId);
            Guard.IsNotNull(category);
            categoryRepository.Remove(category);
            categoryRepository.SaveChanges();
            return new RemoveCategoryOuputModel();
        }
    }
}