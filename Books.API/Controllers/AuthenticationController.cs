using Books.API.Models;
using Books.API.Models.Responses;
using Books.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationLogic _authenticationLogic;

        public AuthenticationController(IAuthenticationLogic authenticationLogic)
        {
            _authenticationLogic = authenticationLogic;
        }

        [HttpPost]
        [Route("login")]
        // This method is used for logging purposes.
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new MessageWrapper("Please enter valid login parametars."));
            }

            var isUserValid = await _authenticationLogic.ValidateUser(loginRequest.Username, loginRequest.Password);

            if (!isUserValid)
            {
                return Unauthorized(new MessageWrapper("Invalid login info."));
            }

            var token = _authenticationLogic.GenerateToken(loginRequest.Username);

            return Ok(new TokenDto()
            {
                Username = loginRequest.Username,
                Token = token.Token,
                Expiration = token.ValidTo
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new MessageWrapper("Registration parameters not valid."));
            }

            var passwardCheck =  _authenticationLogic.ConfirmPassword(registerRequest.Password, registerRequest.confirmPassword);

            if (!passwardCheck)
            {
                return BadRequest(new MessageWrapper("Passwords do not match"));
            }

            var userExists = await _authenticationLogic.UserExists(registerRequest.Username);

            if (userExists)
            {
                return BadRequest(new MessageWrapper("User with same username already exists."));
            }

            var emailUsed = await _authenticationLogic.CheckEmail(registerRequest.Email);

            if (emailUsed)
            {
                return BadRequest(new MessageWrapper("E-mail adress is already in use."));
            }

            var succesfullyCreatedUser = await _authenticationLogic.CreateUser(registerRequest.Username, registerRequest.Password, registerRequest.Email);

            if (!succesfullyCreatedUser)
            {
                return BadRequest(new MessageWrapper("Validation failed, check user details and then try again."));
            }

            return Ok();
        }
    }
}
