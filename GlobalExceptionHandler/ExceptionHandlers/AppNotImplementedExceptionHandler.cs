using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHandler.ExceptionHandlers
{
	public class AppNotImplementedExceptionHandler : IExceptionHandler
	{
		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
		{

			if (exception is NotImplementedException)
			{
				var response = new ErrorReponse()
				{
					StatusCode=StatusCodes.Status501NotImplemented,
					ExceptionMessage=exception.Message,
					Title="Something went wrong"

				};
				
				httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
				await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);				

				return true;

			}

			return false;
		}
	}
}
