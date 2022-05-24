using NetHome.Common;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetHome.Common.JsonConverters
{
    public class RuntimeTypeConverter<T> : JsonConverter<T>
    {
        public override bool CanConvert(Type type)
        {
            return typeof(T).IsAssignableFrom(type);
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
                throw new JsonException();
            if (!reader.Read() || reader.TokenType != JsonTokenType.PropertyName) 
                throw new JsonException();

            string typeName = reader.GetString();
            string qualifiedName = typeof(T).AssemblyQualifiedName.Replace(typeof(T).Name, typeName);
            Type type = Type.GetType(qualifiedName, true);

            var obj = (T)JsonSerializer.Deserialize(ref reader, type);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
                throw new JsonException();
            return obj;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(value.GetType().Name); 
            JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object));
            writer.WriteEndObject();
        }
    }
}