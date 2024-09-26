
using CommunityToolkit.Diagnostics;
using Product.Api.Repositories.Base;
using AutoMapper;
using Product.Api.Mappings.Extensions;
using Product.Api.Dtos.Base;
using Product.Api.Dtos;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class Service<T>(IUrlService urlService, IRepository<T> repository,IMapper mapper) : IService where T : class
    {

        private readonly Repository<T> _repository = (Repository<T>)repository;

        public TResult FindById<TResult>(int id)
        {
            var entity = _repository.FindById(id);
            Guard.IsNotNull(entity);
            return mapper.Map<TResult>(entity, urlService);
        }

        public TResult FindAllById<TResult>(int? id)
        {
            var entity = _repository.FindAllById(id);
            return mapper.Map<TResult>(entity, urlService);
        }

        public TResult Add<TResult>(object inputModel)
        {
            var entity = mapper.Map<T>(inputModel);
            Guard.IsNotNull(entity);
            _repository.Add(entity);
            _repository.SaveChanges();
            return mapper.Map<TResult>(entity, urlService);
        }
    }
}