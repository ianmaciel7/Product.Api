namespace Product.Api.Services
{
    public interface IUrlService
    {
        Uri GetCategories(int? categoryId);
        Uri GetProducts(int? productId);
    }
}