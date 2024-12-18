using Scalar.AspNetCore;
using Product.Api.Extensions;
using Product.Api.Endpoints;
using Product.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddFeatureFlag();
builder.Services.AddServices();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddExceptionHandler<ExceptionHandler>();

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
