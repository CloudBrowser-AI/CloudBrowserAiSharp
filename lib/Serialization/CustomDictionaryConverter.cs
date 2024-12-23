using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace CloudBrowserAiSharp.Serialization;

internal class KeyValuePairConverter<TKey, TValue> : JsonConverter<Dictionary<TKey, TValue>> {
    public override Dictionary<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var dictionary = new Dictionary<TKey, TValue>();

        if (reader.TokenType != JsonTokenType.StartArray) {
            throw new JsonException();
        }

        while (reader.Read()) {
            if (reader.TokenType == JsonTokenType.EndArray) {
                return dictionary;
            }

            if (reader.TokenType == JsonTokenType.StartObject) {
                TKey key = default;
                TValue value = default;

                while (reader.Read()) {
                    if (reader.TokenType == JsonTokenType.EndObject) {
                        dictionary.Add(key, value);
                        break;
                    }

                    if (reader.TokenType == JsonTokenType.PropertyName) {
                        string propertyName = reader.GetString();

                        reader.Read();

                        if (propertyName == "key") {
                            key = JsonSerializer.Deserialize<TKey>(ref reader, options);
                        } else if (propertyName == "value") {
                            value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                        }
                    }
                }
            }
        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<TKey, TValue> value, JsonSerializerOptions options) {
        writer.WriteStartArray();

        foreach (var kvp in value) {
            writer.WriteStartObject();
            writer.WritePropertyName("key");
            JsonSerializer.Serialize(writer, kvp.Key, options);
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, kvp.Value, options);
            writer.WriteEndObject();
        }

        writer.WriteEndArray();
    }
}
