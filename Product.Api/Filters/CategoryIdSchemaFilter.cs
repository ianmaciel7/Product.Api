using Microsoft.OpenApi.Models;
using Product.Api.Data.Entities.ValueObjects;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Product.Api.Filters
{
    public class CategoryIdSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type == typeof(CategoryId))
            {
                schema.Type = "integer";
                schema.Format = "int32";
            }
        }
    }

}
