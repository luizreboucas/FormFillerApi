using Microsoft.AspNetCore.Mvc;
using FormFiller.Domain.Entities;
using System.Threading.Tasks;
using FormFiller.Application.UseCases;
using FormFiller.Infrasctructure.Repositories;

namespace FormFiller.Presentation.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController: ControllerBase
    {
        public UserUseCases userUseCases;
        public UserController(UserUseCases uc)
        {
            userUseCases = uc;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                var allUsers = await userUseCases.GetAllUsers();
                return allUsers;
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }

        }
    }
}
