using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id:guid}")]
        public User Get(Guid id)
        {
            return _userService.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _userService.Insert(value);
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
