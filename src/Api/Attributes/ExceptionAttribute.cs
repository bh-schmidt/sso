using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SSO.Infra.Helpers.Extensions;
using System.Net;

namespace Api.Attributes
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.IsNull())
            {
                return;
            }

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
