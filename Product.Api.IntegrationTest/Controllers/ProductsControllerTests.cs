using FluentAssertions;
using Product.Api.IntegrationTest;
using Product.Api.IntegrationTest.Configurations;
using Product.Api.IntegrationTest.Fakes;
using System.Net;
using System.Net.Http.Json;
using Xunit.Abstractions;

public class ProductsControllerTests(InMemoryServer server, ITestOutputHelper outputHelper) : IntegrationTest(server, outputHelper)
{
    public static string Uri => "/api/v1/products";


    [Fact]
    public async Task Get_All_Products_ReturnsOk()
    {
        // Arrange


        // Act
        var response = await HttpClient.GetAsync(Uri);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Get_Product_By_Id_ReturnsOk()
    {
        // Arrange
        var category = CategoryFaker.Create();
        this.DbContext.Categories.Add(category);

        // Act
        var response = await HttpClient.GetAsync(Uri);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Post_Add_Product_ReturnsOk()
    {
        // Arrange
        var requestUri = "/api/v1/products";
        var newProduct = new { };

        // Act
        var response = await HttpClient.PostAsJsonAsync(Uri, newProduct);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Put_Update_Product_ReturnsOk()
    {
        // Arrange
        var updatedProduct = new { };

        // Act
        var response = await HttpClient.PutAsJsonAsync(Uri, updatedProduct);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Put_Update_Existing_Product_ReturnsOk()
    {
        // Arrange
        var updatedProduct = new { };

        // Act
        var response = await HttpClient.PutAsJsonAsync(Uri, updatedProduct);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public async Task Delete_Remove_Product_ReturnsOk()
    {
        // Arrange

        // Act
        var response = await HttpClient.DeleteAsync(Uri);
        response.EnsureSuccessStatusCode();

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
