using Microsoft.AspNetCore.Mvc;
using SSO.Domain.Auth;
using SSO.Infra.CrossCutting.Attributes;

namespace SSO.Controllers.Auth
{
    [SSOExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IActionResult Authenticate()
        {
            var token = new AuthenticateService().CreateToken();
            return Ok(token);
        }
    }
}
