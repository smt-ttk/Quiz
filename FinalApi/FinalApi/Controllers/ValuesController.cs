using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalApi.DTO;
using FinalApi.Interfaces;
using FinalApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IRepository _repository;

        public ValuesController(IRepository repository)
        {
            _repository = repository;
        }







        [HttpPost]
        public ActionResult Index([FromBody]List<JDto> jDto)
        {
            Console.WriteLine(jDto);

            foreach (var item in jDto)
            {
                User user = new User()
                {
                    id = item.id,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    username = item.username
                };

                var result = _repository.Find(user.id);
                if (result == null)
                {
                    _repository.Insert(user);
                }

            }
            return new JsonResult(_repository.List());
        }


























        // GET api/values
        [HttpPost]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
