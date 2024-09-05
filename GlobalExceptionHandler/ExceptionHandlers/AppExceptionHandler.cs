using GlobalExceptionHandler.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GlobalExceptionHandler.ExceptionHandlers
{
    public class AppExceptionHandler : IExceptionHandler
    {
		private readonly ILogger<AppExceptionHandler> _logger;

		public AppExceptionHandler(ILogger<AppExceptionHandler> logger)
		{
			_logger = logger;
		}

		public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

			

		
            if (exception is not NotImplementedException)
            {
				_logger.LogError(exception, exception.Message);
				var response = new ErrorReponse()
				{
					StatusCode=StatusCodes.Status500InternalServerError,
					ExceptionMessage=exception.Message,
					Title="Something went wrong"

				};
				//const string contentType = "application/json";
				//httpContext.Response.ContentType = contentType;
				//await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response), cancellationToken);

				httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
	

				return true;
			}

			return false;
			
			
		}	
	
    }
}
