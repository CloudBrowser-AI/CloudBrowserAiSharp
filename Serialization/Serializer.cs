using CloudBrowserClient.AI.Types.Response;
using CloudBrowserClient.Browser.Types;
using CloudBrowserClient.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CloudBrowserClient.Serialization;
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
        ToException(status, aIError);
        
        return JsonSerializer.Deserialize<T>(response, JsonSerializerHelper.GetOptionsWithConverters<T>());
    }

    static void ToException(ResponseStatus status, AIError? aiError) {
        switch (status) {
            case ResponseStatus.Succes:
                return;
            default:
            case ResponseStatus.Unknown:
                throw new UnknownException();
            case ResponseStatus.AuthorizationError:
                throw new AuthorizationException();
            case ResponseStatus.NoSubscription:
                throw new NoSubscriptionException();
            case ResponseStatus.NoUnits:
                throw new NoUnitsException();
            case ResponseStatus.BrowserLimit:
                throw new BrowserLimitException();
            case ResponseStatus.AIError:
                switch (aiError) {
                    case AIError.TOO_LONG:
                        throw new AITooLongException();
                    case AIError.CONTENT_FLAGGED:
                        throw new AIContentFlaggedException();
                    case AIError.INVALID_API_KEY:
                        throw new AIInvalidApiKeyException();
                    case AIError.UNKNOWN:
                    case null:
                    default:
                        throw new AIUnknownException();
                }
            case ResponseStatus.LabelInUse:
                throw new LabelInUseException();
        }
    }
}
