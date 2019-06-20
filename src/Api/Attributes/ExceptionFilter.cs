using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Attributes
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = CreateExceptionResponse(context);
        }

        private IActionResult CreateExceptionResponse(ExceptionContext context)
        {
            var jsonResult = new JsonResult(context.Exception.Message);
            jsonResult.StatusCode = HttpStatusCode.InternalServerError.GetHashCode();

            return jsonResult;
        }
    }
}
