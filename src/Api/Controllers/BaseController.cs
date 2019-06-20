using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SSO.Infra.ServiceLocator;
using System;
using System.Linq;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IServiceLocator serviceLocator;

        public BaseController(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        protected virtual IActionResult CreateResponse(ValidationResult validationResult)
        {
            if (validationResult.IsValid)
            {
                return StatusCode(HttpStatusCode.OK.GetHashCode());
            }
            else
            {
                var errors = validationResult.Errors.Select(x => new { x.ErrorCode, x.ErrorMessage });

                return StatusCode(HttpStatusCode.Conflict.GetHashCode(), errors);
            }
        }
    }
}
