using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.DTO;

namespace eCommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            this._usersService = usersService;
        }

        // GET /api/Users/{userID}
        [HttpGet]
        public async Task<IActionResult> GetUserByUserID(Guid UserID)
        {
            if (UserID == Guid.Empty || UserID == null)
            {
                return BadRequest("Invalid UserID");
            }

            UserDTO? response = await _usersService.GetUserByUserID(UserID);

            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
        
}
