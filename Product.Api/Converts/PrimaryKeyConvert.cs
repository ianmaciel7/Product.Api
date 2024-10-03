using Product.Api.Data.Entities.ValueObjects;
using System.Text.Json.Serialization;
using System.Text.Json;

public class CategoryIdConverter : JsonConverter<CategoryId>
{
    public override CategoryId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new CategoryId(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, CategoryId value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}

public class ProductIdConverter : JsonConverter<ProductId>
{
    public override ProductId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return new ProductId(reader.GetInt32());
    }

    public override void Write(Utf8JsonWriter writer, ProductId value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}