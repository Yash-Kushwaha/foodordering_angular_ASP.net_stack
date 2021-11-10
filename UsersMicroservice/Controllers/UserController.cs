using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsersMicroservice.Exceptions;
using UsersMicroservice.Models;
using UsersMicroservice.Service;

namespace UsersMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;
        private readonly ITokenGenerator token;
        public UserController(IUserService service, ITokenGenerator token)
        {
            this.service = service;
            this.token = token;
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                user.Role = "customer";
                return StatusCode(201, service.AddUser(user));
            }
            catch (InvalidPasswordException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserAlreadyExistException e)
            {
                return Conflict(e.Message);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost("admin")]
        public IActionResult PostAdmin(User user)
        {
            try
            {
                user.Role = "admin";
                return StatusCode(201, service.AddUser(user));
            }
            catch (InvalidPasswordException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserAlreadyExistException e)
            {
                return Conflict(e.Message);
            }
        }

        [HttpPost("userlogin")]
        public IActionResult UserLogin(Login user)
        {
            try
            {
                var obj = service.LoginUser(user.Email, user.Password);
                return Ok(token.GenerateJWTToken(obj.Name, obj.Role));
            }
            catch (UserAlreadyExistException e)
            {
                return Unauthorized(e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                return Ok(service.GetAllUser());
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{Id:int}")]
        public IActionResult GetUserById(int Id)
        {
            try
            {
                return Ok(service.GetUserById(Id));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        [HttpGet("{Email}")]
        public IActionResult GetUserByEmail(string Email)
        {
            try
            {
                return Ok(service.GetUserByEmail(Email));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPut("{Id:int}")]
        public IActionResult UpdateUser(int Id, User user)
        {
            try
            {
                return Ok(service.UpdateUserById(Id, user));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{Id:int}")]
        public IActionResult DeleteUser(int Id)
        {
            try
            {
                return Ok(service.DeleteUserById(Id));
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
