using System;

namespace CloudBrowserAiSharp.Exceptions;

public class AuthorizationException : Exception {

}
public class NoSubscriptionException : Exception {

}
public class NoUnitsException : Exception {

}
public class BrowserLimitException : Exception {

}
public class UnknownException : Exception {

}
public class LabelInUseException : Exception {

}

//AI

public abstract class AIException : Exception { }

public class AIContentFlaggedException : AIException {

}
public class AITooLongException : AIException {

}
public class AIInvalidApiKeyException : AIException {

}
public class AIUnknownException : AIException {

}
public class AIQuotaException : AIException {

}