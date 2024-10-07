using AutoMapper;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;
using Product.Api.Mappings.Extensions;
using Product.Api.Repositories;

namespace Product.Api.Services
{
    internal class ProductService(IUrlService urlService, IProductRepository productRepository, IMapper mapper) 
        : Service<Entities.Product, ProductId>(urlService,productRepository,mapper), 
        IProductService
    {
        public IFindProductOutputModel Find(IFindProductInputModel inputModel)
        {
            return base.FindById<IFindProductOutputModel>(inputModel.ProductId);
        }

        public IFindAllProductsOutputModel FindAll(IFindAllProductsInputModel inputModel)
        {
            return base.FindAllById<IFindAllProductsOutputModel>(inputModel.ProductId);
        }

        public IAddProductOutputModel Add(IAddProductInputModel inputModel)
        {
            return base.Add<IAddProductOutputModel>(inputModel);
        }

        public IRemoveProductOutputModel Remove(IRemoveProductInputModel inputModel)
        {
            return base.RemoveById<IRemoveProductOutputModel>(inputModel.ProductId);
        }

        public IUpdateProductOutputModel Update(IUpdateProductInputModel inputModel)
        {
           return base.Update<IUpdateProductOutputModel>(inputModel);
        }
    }
}
