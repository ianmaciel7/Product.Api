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
    public class CategoriesControllerTest(InMemoryServer server, ITestOutputHelper outputHelper) : IntegrationTest(server, outputHelper)
    {
        public static string Uri => "/api/v1/categories";


        [Fact]
        public async Task Get_All_Categories_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateCategory(out var category)
                     .GenerateCategory(out var category2);

            // Act
            var response = await HttpClient.GetAsync(Uri);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Get_Category_By_Id_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateCategory(out var category);

            // Act
            var response = await HttpClient.GetAsync(Uri);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Post_Add_Category_ReturnsOk()
        {
            // Arrange
            var category = CategoryFaker.GenerateDefault();

            // Act
            var response = await HttpClient.PostAsJsonAsync(Uri, category);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();


            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Put_Update_Category_ReturnsOk()
        {
            // Arrange
            var category = CategoryFaker.GenerateDefault();

            // Act
            var response = await HttpClient.PutAsJsonAsync(Uri, category);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Put_Update_Existing_Category_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateCategory(out var category);
            if (category is null)
            {
                OutputHelper.WriteLine("Category is null");
                return;

            }
            var url = $"{Uri}/{category.CategoryId}";
            var newCategory = CategoryFaker.GenerateDefault();

            category = new()
            {
                CategoryId = category.CategoryId,
                Name = newCategory.Name,
                Description = newCategory.Description,
                Children = [],
                Products = [],
                Parent = null,
                ParentId = null
            };

            // Act
            var response = await HttpClient.PutAsJsonAsync(url, category);
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_Remove_Category_ReturnsOk()
        {
            // Arrange
            DbContext.GenerateCategory(out var category);

            // Act
            var response = await HttpClient.DeleteAsync($"{Uri}/{category.CategoryId}");
            OutputHelper.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}