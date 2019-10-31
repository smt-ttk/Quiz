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
                    //id = item.id,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    username = item.username
                };
                var result = _repository.FindUserName(user.username);
                if (result == null)
                {
                    _repository.Insert(user);
                }

            }
            return new JsonResult(_repository.List());
        }


       
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(_repository.List());
        }


        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }
       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
