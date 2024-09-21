using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Product.Api.Filters
{
    public class FixSchemaFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            foreach (var item in context.ApiDescription.ActionDescriptor.Parameters)
            {
                context.SchemaGenerator.GenerateSchema(item.ParameterType, context.SchemaRepository);
            }
        }
    }
}
