using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eCommerce.Core.ServiceContracts;
using eCommerce.Core.DTO;

namespace eCommerce.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register
            (RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid registration request");
            }

            AuthenticationResponse authenticationResponse =  await _usersService.Register(registerRequest);
            if(authenticationResponse == null || authenticationResponse.Success == false)
            {
                return BadRequest("User registration failed");
            }

            return Ok(authenticationResponse);
        }


        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Invalid login request");
            }

            AuthenticationResponse authenticationResponse = await _usersService.Login(loginRequest);

            if (authenticationResponse == null || authenticationResponse.Success == false)
            {
                return Unauthorized(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }

        [Route("All")]
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            return Ok("Hi, I am working");

        }
    }
}