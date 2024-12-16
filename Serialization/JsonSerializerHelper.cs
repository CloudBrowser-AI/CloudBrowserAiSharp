using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Collections;
using System.Linq;

namespace CloudBrowserAiSharp.Serialization;

internal static class JsonSerializerHelper {
    public static JsonSerializerOptions GetOptionsWithConverters<T>() {
        JsonSerializerOptions options = new();
        HashSet<Type> visitedTypes = [];
        var idictionaryTypes = GetIDictionaryTypes(typeof(T), visitedTypes);

        foreach (var (keyType, valueType) in idictionaryTypes) {
            var converterType = typeof(KeyValuePairConverter<,>).MakeGenericType(keyType, valueType);
            var converter = (JsonConverter)Activator.CreateInstance(converterType);
            options.Converters.Add(converter);
        }

        return options;
    }

    static bool ImplementsInterface(Type original, Type interfaceI) => original.GetInterfaces().Any(i => i == interfaceI);
    static List<(Type KeyType, Type ValueType)> GetIDictionaryTypes(Type type, HashSet<Type> visitedTypes) {
        List<(Type, Type)> idictionaryTypes = [];

        if (visitedTypes.Contains(type))
            return idictionaryTypes;

        visitedTypes.Add(type);

        foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
            var propertyType = property.PropertyType;

            if (propertyType.IsGenericType && ImplementsInterface(propertyType, typeof(IDictionary))) {
                var genericArguments = propertyType.GetGenericArguments();
                if (genericArguments.Length == 2)
                    idictionaryTypes.Add((genericArguments[0], genericArguments[1]));
            } else if (!propertyType.IsPrimitive && propertyType != typeof(string)) {
                idictionaryTypes.AddRange(GetIDictionaryTypes(propertyType, visitedTypes));
            }
        }

        return idictionaryTypes;
    }
}

