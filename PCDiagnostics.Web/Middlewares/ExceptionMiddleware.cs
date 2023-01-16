using PCDiagnostics.Core.Exceptions;

namespace PCDiagnostics.Web.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (ObjectNotFoundException ex)
		{
			context.Response.StatusCode = StatusCodes.Status404NotFound;
			await context.Response.WriteAsJsonAsync(new { Message = ex.Message });
		}
		catch (Exception)
		{
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			await context.Response.WriteAsJsonAsync(
				new { Message = "Internal Server Error" });
		}
	}
}
