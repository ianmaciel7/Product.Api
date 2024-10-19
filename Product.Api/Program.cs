using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Product.Api.Data;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Filters;
using Product.Api.Repositories;
using Product.Api.Services;
using System.ComponentModel;
using Product.Api.Converts;
using Microsoft.FeatureManagement;
using Product.Api.Contants;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
TypeDescriptor.AddAttributes(typeof(CategoryId), new TypeConverterAttribute(typeof(CategoryIdTypeConverter)));
TypeDescriptor.AddAttributes(typeof(ProductId), new TypeConverterAttribute(typeof(ProductIdTypeConverter)));

builder.Services.AddControllers().AddJsonOptions(options =>
{
   options.JsonSerializerOptions.Converters.Add(new CategoryIdConverter());
   options.JsonSerializerOptions.Converters.Add(new ProductIdConverter());
});
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(e =>
{
    var id = new OpenApiSchema { Type = "integer", Format = "int32" };
    e.OperationFilter<FixSchemaFilter>();
    e.EnableAnnotations();
    e.MapType<CategoryId>(() => id);
    e.MapType<ProductId>(() => id);
});
builder.Services.AddDbContext<ApplicationDbContext>(async (serviceProvider, options) =>
{
    var featureManager = serviceProvider.GetRequiredService<IFeatureManager>();

    var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var databaseProvider = builder.Configuration.GetValue<string>("DatabaseProvider");
    var defaultDatabaseName = builder.Configuration.GetValue<string>("DefaultDatabaseName");
    var isInMemoryDatabase = databaseProvider == FeatureFlag.DatabaseProvider.InMemory;
    var isUseSqlServer = databaseProvider == FeatureFlag.DatabaseProvider.SqlServer;

    options.UseSqlServer(defaultConnectionString);

    if (isUseSqlServer && isInMemoryDatabase)
    {
        options.UseInMemoryDatabase(defaultDatabaseName);
    }
});
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddFeatureManagement();
// send HttpContext
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
