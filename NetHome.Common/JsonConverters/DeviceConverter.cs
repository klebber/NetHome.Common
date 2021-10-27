﻿using NetHome.Common.Models;
using NetHome.Common.Models.Devices;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NetHome.Common.JsonConverters
{
    public class DeviceConverter : JsonConverter<DeviceModel>
    {
        public override bool CanConvert(Type type)
        {
            return typeof(DeviceModel).IsAssignableFrom(type);
        }

        public override DeviceModel Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            DeviceModel device;
            string typeName = reader.GetString();
            string qualifiedName = $"NetHome.Common.Models.Devices.{typeName}, NetHome.Common";
            Type type = Type.GetType(qualifiedName, true);


            device = (DeviceModel)JsonSerializer.Deserialize(ref reader, type);

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return device;
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeviceModel value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            writer.WritePropertyName(value.GetType().Name);
            JsonSerializer.Serialize(writer, value);

            writer.WriteEndObject();
        }
    }
}