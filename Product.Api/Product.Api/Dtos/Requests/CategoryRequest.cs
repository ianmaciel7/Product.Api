namespace Product.Api.Dtos.Requests
{
    public record CategoryRequest(
        string Name,
        string Description,
        IEnumerable<CategoryRequest.ProductRequest> Products,
        IEnumerable<CategoryRequest.ChildrenRequest> Children,
        Guid? ParentId = null
    )
    {
        public record ChildrenRequest(
            string Name,
            string Description,
            IEnumerable<CategoryRequest.ProductRequest> Products,
            IEnumerable<ChildrenRequest> Children
        );

        public record ProductRequest(
            string Name,
            decimal Price,
            string Description
        );
    }

    

}
