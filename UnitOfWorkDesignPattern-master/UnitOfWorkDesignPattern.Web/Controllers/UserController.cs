using System;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDesignPattern.Data.Interfaces;
using UnitOfWorkDesignPattern.Data.Models;

namespace UnitOfWorkDesignPattern.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetUsers()
        {
            return new JsonResult(_unitOfWork.UserRepository.List());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _unitOfWork.UserRepository.Find(id);
            if (user == null) return NotFound();
            return new JsonResult(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult PostUser(User user)
        {
            _unitOfWork.UserRepository.Insert(user);
            _unitOfWork.Complete();
            return new JsonResult(user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return new JsonResult(new Tuple<bool, int>(_unitOfWork.UserRepository.Delete(id), _unitOfWork.Complete()));
        }
    }
}