using FluentAssertions;
using Product.Api.Data.Entities.ValueObjects;
using Product.Api.IntegrationTest.Configurations;
using Product.Api.IntegrationTest.Extensions;
using Product.Api.IntegrationTest.Fakes;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

namespace Product.Api.IntegrationTest.Controllers.V1
{
    public class ProductsControllerTests(TestServer server, ITestOutputHelper outputHelper) : IntegrationTest(server, outputHelper)
    {
        public static string Uri => "/api/v1/products";


        [Fact]
        public async Task Get_All_Products_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateProduct(out var product)
                     .GenerateProduct(out var product2);

            // Act
            var response = await HttpClient.GetAsync(Uri);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Product_By_Id_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateProduct(out var product);

            // Act
            var response = await HttpClient.GetAsync(Uri);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Add_Product_ReturnsOk()
        {
            // Arrange
            var product = ProductFaker.GenerateDefault();

            // Act
            var response = await HttpClient.PostAsJsonAsync(Uri, product);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();


            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Put_Update_Product_ReturnsOk()
        {
            // Arrange
            var product = ProductFaker.GenerateDefault();

            // Act
            var response = await HttpClient.PutAsJsonAsync(Uri, product);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Put_Update_Existing_Product_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateProduct(out var product);
            if (product is null)
            {
                OutputHelper.WriteLine("Product is null");
                return;

            }
            var url = $"{Uri}/{product.ProductId}";
            var newProduct = ProductFaker.GenerateDefault();
            var newCategory = DbContext.FindRandomCategory(new HashSet<CategoryId>() { product.CategoryId });

            product = new()
            {
                ProductId = product.ProductId,
                Name = newProduct.Name,
                Description = newProduct.Description,
                Price = newProduct.Price,
                CategoryId = newCategory.CategoryId,
                Category = null
            };

            // Act
            var response = await HttpClient.PutAsJsonAsync(url, product);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_Remove_Product_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateProduct(out var product);

            // Act
            var response = await HttpClient.DeleteAsync($"{Uri}/{product.ProductId}");
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}