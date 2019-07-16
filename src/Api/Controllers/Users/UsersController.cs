using Microsoft.AspNetCore.Mvc;
using SSO.Domain.Interfaces.Users;
using SSO.Domain.Models.Entities.Users;
using SSO.Infra.ServiceLocator;
using System.Threading.Tasks;

namespace Api.Controllers.Users
{
    public class UsersController : BaseController
    {
        public UsersController(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        [HttpPost]
        [Route("InsertNew")]
        public async Task<IActionResult> InsertNew(User user)
        {
            var insertUserService = serviceLocator.Resolve<IInsertUserService>();
            var userReturned = await insertUserService.Insert(user);

            return CreateResponse(userReturned.ValidationResult);
        }
    }
}
