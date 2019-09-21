using Api.Infra.CrossCutting.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Infra.CrossCutting.Attributes
{
    public class SSOExceptionFilter : ExceptionFilterAttribute
    {
        private const string ErrorMessage = "An error ocurred while processing the information.";

        public override void OnException(ExceptionContext context)
        {
            if (context.IsNull())
            {
                return;
            }

            context.Result = CreateExceptionResponse();
        }

        private IActionResult CreateExceptionResponse()
        {
            var jsonResult = new JsonResult(ErrorMessage)
            {
                StatusCode = HttpStatusCode.InternalServerError.GetHashCode()
            };

            return jsonResult;
        }
    }
}
