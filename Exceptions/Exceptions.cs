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

public class AIContentFlaggedException : Exception {

}
public class AITooLongException : Exception {

}
public class AIInvalidApiKeyException : Exception {

}
public class AIUnknownException : Exception {

}