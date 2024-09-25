using Product.Api.Dtos.Base;

namespace Product.Api.Dtos
{
    public record FindCategoryOutputModel(
            int CategoryId, 
            string Name, 
            IEnumerable<Uri> Children,
            IEnumerable<Uri> Products,
            Uri Parent
        ) : IFindCategoryOutputModel,
            IAddCategoryOutputModel,
            IRemoveCategoryOuputModel;
}
