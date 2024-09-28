using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryOutputModel(
            CategoryId CategoryId, 
            string Name, 
            IEnumerable<IFindCategoryOutputModel> Children
        ) : IFindCategoryOutputModel,
            IAddCategoryOutputModel,
            IRemoveCategoryOuputModel,
            IUpdateCategoryOutputModel;
}
