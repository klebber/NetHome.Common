using NetHome.Common.Models;
using NetHome.Common.Models.Devices;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetHome.Common.JsonConverters
{
    public class RuntimeTypeConverter<T> : JsonConverter<T>
    {
        private readonly string assembly1;
        private readonly string assembly2;
        public RuntimeTypeConverter(string assembly1, string assembly2)
        {
            this.assembly1 = assembly1;
            this.assembly2 = assembly2;
        }
        public override T Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (!reader.Read() || reader.TokenType != JsonTokenType.PropertyName) 
                throw new JsonException();
            string typeName = reader.GetString();
            string qualifiedName = $"{assembly1}{typeName}, {assembly2}";
            Type type = Type.GetType(qualifiedName, true);

            return (T)JsonSerializer.Deserialize(ref reader, type); ;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(value.GetType().Name);
            JsonSerializer.Serialize(writer, value, value?.GetType() ?? typeof(object), options);
        }
    }
}