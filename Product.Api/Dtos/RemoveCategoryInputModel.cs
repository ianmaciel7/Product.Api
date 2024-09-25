using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record RemoveCategoryInputModel(int CategoryId) : IRemoveCategoryInputModel;
}
