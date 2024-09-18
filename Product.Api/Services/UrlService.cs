using Product.Api.Dtos;

namespace Product.Api.Services
{
    public class UrlService(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor) : IUrlService
    {
        private readonly LinkGenerator _linkGenerator = linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Uri GetAllCategoriesUri(FindAllCategoriesInputModel inputModel)
        {
            return GetUri(GET_ALL_CATEGORIES, inputModel);
        }
        public Uri GetCategoryUri(FindCategoryInputModel inputModel)
        {
            return GetUri(GET_CATEGORY, inputModel);
        }

        public Uri GetAllProductsUri(FindAllProductsInputModel inputModel)
        {
            return GetUri(GET_ALL_PRODUCTS, inputModel);
        }

        public Uri GetProductUri(FindAllProductsInputModel inputModel)
        {
            return GetUri(GET_PRODUCT, inputModel);
        }

        private Uri GetUri(string name, object? values=null)
        {
            var httpContext = _httpContextAccessor.HttpContext ?? throw new InvalidOperationException("HttpContext is null");
            string url = _linkGenerator.GetUriByName(httpContext, name, values) ?? "";
            return new Uri(url);
        }
    }
}
