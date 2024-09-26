
using CommunityToolkit.Diagnostics;
using Product.Api.Repositories.Base;
using AutoMapper;
using Product.Api.Mappings.Extensions;

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
    }
}