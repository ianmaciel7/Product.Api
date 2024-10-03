using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Product.Api.Data;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.Filters;
using Product.Api.Repositories;
using Product.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


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
builder.Services.AddDbContext<ApplicationDbContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddAutoMapper(typeof(Program));
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
