using System.Text.Json;
using System.Text.Json.Serialization;

public class PrimaryKeyConvert<T> : JsonConverter<T>
{
    private readonly Func<T, object> _convert;

    public PrimaryKeyConvert(Func<T, object> convert)
    {
        _convert = convert ?? throw new ArgumentNullException(nameof(convert));
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var result = JsonSerializer.Deserialize<T>(ref reader, options);
        if (result == null)
        {
            throw new JsonException($"Unable to deserialize {typeof(T)}");
        }
        result = (T)_convert(result);
        return result;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        var convertedValue = _convert(value);
        JsonSerializer.Serialize(writer, convertedValue, options);
    }
}
