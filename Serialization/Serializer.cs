using CloudBrowserAiSharp.AI.Types.Response;
using CloudBrowserAiSharp.Browser.Types;
using CloudBrowserAiSharp.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Serialization;
internal static class Serializer {
    public static string ToResponseFormat<T>() => TypeSerializer.GetSchema<T>();

    internal class Wrapper<T> {
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
    public static async Task<T> ToObject<T>(Task<AIResponse> t) {
        var rp = await t.ConfigureAwait(false);
        var ob = ToObject<Wrapper<T>>(rp.Response, rp.Status, rp.OpenAiError);
        return ob.Response;
    }
    public static T ToObject<T>(AIResponse rp) => ToObject<T>(rp.Response, rp.Status, rp.OpenAiError);

    public static T ToObject<T>(string response, ResponseStatus status, AIError? aIError = null) {
        ExceptionHelper.ToException(status, aIError);

        return JsonSerializer.Deserialize<T>(response, JsonSerializerHelper.GetOptionsWithConverters<T>());
    }
}
