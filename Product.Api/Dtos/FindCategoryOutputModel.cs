using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryOutputModel(
            int CategoryId, 
            string Name, 
            IEnumerable<IFindCategoryOutputModel> Children
        ) : IFindCategoryOutputModel,
            IAddCategoryOutputModel,
            IRemoveCategoryOuputModel,
            IUpdateCategoryOutputModel;
}
