using Product.Api.Data.Entities.ValueObjects;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.ComponentModel;
using System.Globalization;

namespace Product.Api.Converts
{
    public class CategoryIdConverter : JsonConverter<CategoryId>
    {
        public override CategoryId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if(reader.TokenType is JsonTokenType.EndObject or JsonTokenType.StartObject)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                var categoryId = doc.RootElement.GetProperty("value").GetInt32();
                return new CategoryId(categoryId);
            }
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
            if (reader.TokenType is JsonTokenType.EndObject or JsonTokenType.StartObject)
            {
                using var doc = JsonDocument.ParseValue(ref reader);
                var categoryId = doc.RootElement.GetProperty("value").GetInt32();
                return new ProductId(categoryId);
            }
            return new ProductId(reader.GetInt32());
        }

        public override void Write(Utf8JsonWriter writer, ProductId value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value.Value);
        }
    }

    public class CategoryIdTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string strValue)
            {
                if (int.TryParse(strValue, out var intValue))
                {
                    return new CategoryId(intValue);
                }
                throw new FormatException($"Cannot convert '{strValue}' to {nameof(CategoryId)}.");
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object value, Type destinationType)
        {
            if (value is CategoryId categoryId && destinationType == typeof(string))
            {
                return categoryId.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    public class ProductIdTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (value is string strValue)
            {
                if (int.TryParse(strValue, out var intValue))
                {
                    return new ProductId(intValue);
                }
                throw new FormatException($"Cannot convert '{strValue}' to {nameof(CategoryId)}.");
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object value, Type destinationType)
        {
            if (value is ProductId categoryId && destinationType == typeof(string))
            {
                return categoryId.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}