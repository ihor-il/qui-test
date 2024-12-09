using WeatherApp.Api.Abstract;

namespace WeatherApp.Api.Utilities
{
    public class SessionService(IHttpContextAccessor context) : ISessionService
    {
        public Guid CreateSession()
        {
            if (context.HttpContext == null) return Guid.Empty;
            var request = context.HttpContext.Request;
            var response = context.HttpContext.Response;

            var hasSession = request.Cookies.TryGetValue(Constants.SESSION_ID_COOKIE, out var sessionIdStr);
            if (hasSession && Guid.TryParse(sessionIdStr, out var sessionId)) return sessionId;

            sessionId = Guid.NewGuid();

            response.OnStarting(() =>
            {
                response.Cookies.Append(Constants.SESSION_ID_COOKIE, Guid.NewGuid().ToString());
                return Task.CompletedTask;
            });

            return sessionId;
        }
    }
}
