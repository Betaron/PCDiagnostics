using PCDiagnostics.Core.Domains.User.Services;

namespace PCDiagnostics.Web.Middlewares;

public class AuthMiddleware
{
	private readonly RequestDelegate _next;

	public AuthMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IUserService userService)
	{
		var authLine = context.Request.Headers["Auth"].ToString();
		if (string.IsNullOrEmpty(authLine) &&
			context.Request.Method == "POST" &&
			(context.Request.Path == "/device" || context.Request.Path == "/diagnostic"))
		{
			await _next(context);
			return;
		}

		string login = "";
		if (!string.IsNullOrEmpty(authLine))
			login = authLine.Split(':')[0];

		var user = await userService.GetByLoginAsync(login, CancellationToken.None);

		if ($"{user.Login}:{user.Key}" == authLine)
			await _next(context);
	}
}
