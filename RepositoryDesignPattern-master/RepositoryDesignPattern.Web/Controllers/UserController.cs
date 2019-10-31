using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Data.Interfaces;
using RepositoryDesignPattern.Data.Models;

namespace RepositoryDesignPattern.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            return new JsonResult(_userRepository.List());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _userRepository.Find(id);
            if (user == null) return NotFound();
            return new JsonResult(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            _userRepository.Update(user);

            return new JsonResult(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _userRepository.Insert(user);
            return new JsonResult(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return new JsonResult(_userRepository.Delete(id));
        }
    }
}