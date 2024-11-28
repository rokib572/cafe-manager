using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Filters
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			var response = new
			{
				Message = context.Exception.Message,
				StackTrace = context.Exception.StackTrace
			};

			context.Result = new ObjectResult(response)
			{
				StatusCode = 500
			};

			context.ExceptionHandled = true;
		}
	}
}
