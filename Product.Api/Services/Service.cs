
using CommunityToolkit.Diagnostics;
using Product.Api.Repositories.Base;
using AutoMapper;
using Product.Api.Mappings.Extensions;

namespace Product.Api.Services
{
    internal class Service<T,TId>(IUrlService urlService, IRepository<T> repository,IMapper mapper)
        : IService where T : class where TId : class
    {

        private readonly Repository<T, TId> _repository = (Repository<T, TId>)repository;

        public TResult FindById<TResult>(TId id)
        {
            var entity = _repository.FindById(id);
            Guard.IsNotNull(entity);
            return mapper.Map<TResult>(entity, urlService);
        }

        public TResult FindAllById<TResult>(TId? id)
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

        public TResult RemoveById<TResult>(TId id)
        {
            var entity = _repository.FindById(id);
            Guard.IsNotNull(entity);
            _repository.Remove(entity);
            _repository.SaveChanges();
            return mapper.Map<TResult>(entity, urlService);
        }

        public TResult Update<TResult>(object inputModel)
        {
            var product = mapper.Map<T>(inputModel);
            _repository.Update(product);
            _repository.SaveChanges();
            return mapper.Map<TResult>(product, urlService);
        }
    }
}