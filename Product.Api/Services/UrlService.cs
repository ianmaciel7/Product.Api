namespace Product.Api.Services
{
    public class UrlService(LinkGenerator linkGenerator, IHttpContextAccessor httpContextAccessor) : IUrlService
    {
        private readonly LinkGenerator _linkGenerator = linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

        public Uri GetCategories(int? categoryId)
        {
            return GetResourceOrGetPath(GET_CATEGORIES, categoryId.Value);
        }

        public Uri GetProducts(int? productId)
        {
            return GetResourceOrGetPath(GET_PRODUCTS, productId.Value);
        }

        private Uri GetResourceOrGetPath(string path, int? id)
        {
            string url = _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, path, new { id }) ?? "";
            return new Uri(url);
        }

        private Uri GetPath(string path)
        {
            string url = _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, path) ?? "";
            return new Uri(url);
        }

        private Uri GetResource(string context,int id)
        {
            string url = _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, context, new { id }) ?? "";
            return new Uri(url);
        }
    }
}
