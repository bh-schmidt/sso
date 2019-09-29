using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SSO.Infra.CrossCutting.ExtensionMethods;
using System.Diagnostics;
using System.Net;

namespace SSO.Infra.CrossCutting.Attributes
{
    public class SsoExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private const string ErrorMessage = "An error ocurred while processing the information.";

        public override void OnException(ExceptionContext context)
        {
            if (!context.IsNull() && !context.Exception.IsNull())
            {
                Debug.WriteLine($"Error: {context.Exception.Message}");
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
