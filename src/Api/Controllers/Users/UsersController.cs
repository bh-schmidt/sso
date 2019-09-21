using Api.Domain.Users;
using Api.Domain.Users.InsertUsers;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using Microsoft.AspNetCore.Mvc;
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
