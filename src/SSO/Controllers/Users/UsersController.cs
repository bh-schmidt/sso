using Microsoft.AspNetCore.Mvc;
using SSO.Domain.Users;
using SSO.Domain.Users.InsertUsers;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System.Threading.Tasks;

namespace SSO.Controllers.Users
{
    public class UsersController : BaseController
    {
        public UsersController(IServiceLocator serviceLocator) : base(serviceLocator)
        {
        }

        [HttpPost]
        [Route("InsertNew")]
        public async Task<IActionResult> InsertNew(User? user)
        {
            var insertUserService = serviceLocator.Resolve<IInsertUserService>();
            var userReturned = await insertUserService.Insert(user);

            return CreateResponse(userReturned.ValidationResult);
        }
    }
}
