using Scalar.AspNetCore;
using Product.Api.Extensions;
using Product.Api.Endpoints.V1;
using Product.Api.Models.ValueObjects;
using Product.Api.OpenApi;
using Product.Api.Converters;
using System.Text.Json;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
TypeDescriptor.AddAttributes(typeof(CategoryId), new TypeConverterAttribute(typeof(PrimaryKeyConverter<CategoryId>)));
TypeDescriptor.AddAttributes(typeof(ProductId), new TypeConverterAttribute(typeof(PrimaryKeyConverter<ProductId>)));


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new PrimaryKeyConverter<ProductId>());
    options.JsonSerializerOptions.Converters.Add(new PrimaryKeyConverter<CategoryId>());
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(op =>
{
    op.AddSchemaTransformer(new PrimaryKeyTransformer<ProductId>());
    op.AddSchemaTransformer(new PrimaryKeyTransformer<CategoryId>());
});

builder.Services.AddFeatureFlag();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.MapCategoriesEndpoints();
app.MapProductEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
