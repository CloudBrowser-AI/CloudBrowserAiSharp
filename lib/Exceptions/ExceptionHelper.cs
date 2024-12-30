using CloudBrowserAiSharp.AI.Types.Response;
using CloudBrowserAiSharp.Browser.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudBrowserAiSharp.Exceptions;

public static class ExceptionHelper {
    public static void ToException(ResponseStatus status, AIError? aiError) {
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
                    case AIError.QUOTA:
                        throw new AIQuotaException();
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
