using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Handlers;
using TaskManager.API.Models;
using TaskManager.BLL.Entities;
using TaskManager.Common.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository<BLL.Entities.User> _userService;

        public UserController(IUserRepository<User> userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [ProducesResponseType<EnumerableResult<User>>(200)]
        public async Task<IActionResult> Get()
        {
            return Ok(new EnumerableResult<User>()
            {
                Result = await _userService.Get().ToArrayAsync()
            });
        }

        // GET api/<UserController>/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType<User>(200)]
        [ProducesResponseType<ErrorResponse>(404)]
        [ProducesResponseType(418)]
        public async Task<ActionResult<User>> Get(Guid id)
        {
            try
            {
                return _userService.Get(id);
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound(new ErrorResponse() { 
                    Route = HttpContext.Request.GetEncodedUrl(),
                    Controller = nameof(UserController),
                    Action = nameof(Get),
                    StatusCode = 404,
                    RoutesValues = new { id }
                });
            }
            catch (Exception)
            {
                return StatusCode(418);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public Guid Post([FromBody] UserPost value)
        {
            return _userService.Insert(value.ToBLL());
        }

        [HttpPost("Login")]
        public User? CheckPassword([FromBody]UserPost value)
        {
            try
            {
                return _userService.CheckPassword(value.Email, value.Password);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        [HttpPost("Login/{email:length(3,320)}/{password:length(8,64)}")]
        public User? CheckPassword([FromRoute]string email, [FromRoute]string password)
        {
            try
            {
                return _userService.CheckPassword(email, password);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        [HttpPost("Login2")]
        public User? CheckPassword2([FromQuery] string email, [FromQuery] string password)
        {
            try
            {
                return _userService.CheckPassword(email, password);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        /*Not implemented
        // PUT api/<UserController>/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] User value)
        {
            _userService.Update(id, value);
        }*/

        // DELETE api/<UserController>/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
    }
}
