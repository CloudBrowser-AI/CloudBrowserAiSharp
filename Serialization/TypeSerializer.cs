using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Data;
using System.Collections;

namespace CloudBrowserAiSharp.Serialization;
internal static class TypeSerializer {
    public static string GetSchema<T>() => GetSchema(typeof(T));
    public static string GetSchema(Type type) => GenerateSchema(type).ToJsonString();
    static JsonObject GenerateSchema(Type type) {
        JsonObject refs = [];
        var wrapper = Obj(
            new JsonObject { ["response"] = GenerateSchema(type, refs) },
            new JsonArray(["response"])
        );
        if (refs.Count > 0)
            wrapper["$defs"] = refs;
        return wrapper;
    }
    static JsonObject GenerateSchema(Type type, JsonObject refs) {
        if (type.IsEnum)
            return GenerateEnumSchema(type);

        if (type.IsArray)
            return GenerateArraySchema(type, refs);

        if (type == typeof(bool))
            return GenerateBoolSchema();

        if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
            return GenerateNumberSchema();

        if (type == typeof(int) || type == typeof(byte) || type == typeof(short) || type == typeof(long) || type == typeof(uint) || type == typeof(ushort) || type == typeof(ulong))
            return GenerateIntegerSchema();

        if (Nullable.GetUnderlyingType(type) != null)
            return GenerateSchema(Nullable.GetUnderlyingType(type), refs);

        if (type == typeof(string) || type == typeof(char))
            return GenerateStringSchema();

        if (type == typeof(DateTime) || type == typeof(DateTimeOffset))
            return GenerateDateTimeSchema();

        if (type == typeof(DateTime) || type == typeof(Guid))
            return GenerateGuidSchema();

        if (type == typeof(object))
            return GenerateObjectSchema();

        //Since IDictionary implements IEnumerable, this has to be before IEnumerable
        if (ImplementsInterface(type, typeof(IDictionary)))
            return GenerateDictionarySchema(type, refs);

        if (ImplementsInterface(type, typeof(IEnumerable)))
            return GenerateEnumerableSchema(type, refs);

        if (type.IsClass)
            return GenerateClassSchema(type, refs);

        //Any other type string
        return GenerateStringSchema();
    }
    static bool ImplementsInterface(Type original, Type interfaceI) => original.GetInterfaces().Any(i => i == interfaceI);
    static JsonObject GeneratePrimitiveSchema(string type) => new() { ["type"] = type };
    static JsonObject GeneratePrimitiveSchema(string type, string format) => new() { ["type"] = type, ["format"] = format };
    static JsonObject GenerateBoolSchema() => GeneratePrimitiveSchema("boolean");
    static JsonObject GenerateNumberSchema() => GeneratePrimitiveSchema("number");
    static JsonObject GenerateIntegerSchema() => GeneratePrimitiveSchema("integer");
    static JsonObject GenerateStringSchema() => GeneratePrimitiveSchema("string");
    static JsonObject GenerateObjectSchema() => GeneratePrimitiveSchema("object");
    static JsonObject GenerateDateTimeSchema() => GeneratePrimitiveSchema("string", "format");
    static JsonObject GenerateGuidSchema() => GeneratePrimitiveSchema("string", "uuid");
    static JsonObject GenerateEnumSchema(Type type) {
        return new() {
            ["type"] = "string",
            ["enum"] = ToJsonArray([.. Enum.GetNames(type)])
        };
    }
    static JsonObject GenerateArraySchema(Type type, JsonObject refs) {
        var elementType = type.GetElementType() ?? typeof(string);
        return Arr(GenerateSchema(elementType, refs));
    }
    static JsonObject GenerateEnumerableSchema(Type type, JsonObject refs) {
        var elementType = type.GetGenericArguments()[0] ?? typeof(string);
        return Arr(GenerateSchema(elementType, refs));
    }
    static JsonObject GenerateDictionarySchema(Type type, JsonObject refs) {
        if (!type.IsGenericType)
            throw new InvalidOperationException($"Incompatible dictionary {type.FullName}");

        Type[] types = type.GetGenericArguments();
        if (types.Length != 2)
            throw new InvalidOperationException($"Incompatible dictionary {type.FullName}");

        //if (types[0] != typeof(string))
        //    throw new InvalidOperationException($"throw new ArgumentException($\"Dictionaries must have a string key. {type.FullName} violates this rule.");

        var elementType = Nullable.GetUnderlyingType(types[1]) ?? types[1];
        return Arr(
            Obj(new JsonObject() {
                ["key"] = GenerateSchema(types[0], refs),
                ["value"] = GenerateSchema(types[1], refs),
            }, new(["key", "value"]))
        );
    }
    static JsonObject GenerateClassSchema(Type type, JsonObject refs) {
        if (refs.ContainsKey(type.FullName))
            return CreateReference(type.FullName);

        JsonObject properties = [];
        HashSet<string> required = [];

        JsonObject def = new() {
            ["type"] = "object",
            ["additionalProperties"] = false
        };
        refs[type.FullName] = def; //This must go before the loop or infinite recursion may occur.
        MemberInfo[] members = [.. type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public), .. type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)];
        foreach (var member in members) {
            var memberT = GetType(member);
            JsonPropertyNameAttribute nameAttribute = member.GetCustomAttribute<JsonPropertyNameAttribute>();
            JsonIgnoreAttribute ignoreAttribute = member.GetCustomAttribute<JsonIgnoreAttribute>();

            var name = nameAttribute?.Name ?? member.Name;
            properties[name] = GenerateSchema(GetType(member), refs);

            if (Nullable.GetUnderlyingType(memberT) == null)
                required.Add(name); //If it can't be null, we will assume it is required

            switch (ignoreAttribute?.Condition) {
                case JsonIgnoreCondition.WhenWritingDefault:
                case JsonIgnoreCondition.Never:
                    required.Add(name);
                    break;
                case null:
                    break;
                default:
                    required.Remove(name);
                    break;
            }
        }

        def["properties"] = properties;
        if (required.Count > 0)
            def["required"] = ToJsonArray([.. required]);

        return CreateReference(type.FullName);
    }
    static JsonObject CreateReference(string name) => new() { ["$ref"] = "#/$defs/" + name };
    static JsonArray ToJsonArray(string[] values) => new(values.Select(x => JsonValue.Create(x)).ToArray());
    static Type GetType(MemberInfo member) {
        if (member is FieldInfo info)
            return info.FieldType;

        return ((PropertyInfo)member).PropertyType;
    }

    static JsonObject Obj(JsonObject properties, JsonArray required) {
        return new() {
            ["type"] = "object",
            ["properties"] = properties,
            ["required"] = required,
            ["additionalProperties"] = false
        };
    }
    static JsonObject Arr(JsonObject items) {
        return new() {
            ["type"] = "array",
            ["items"] = items
        };
    }
}
