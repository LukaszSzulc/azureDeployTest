using AzureDeployTests.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AzureDeployTests.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        private readonly AzureDeployContext context = new AzureDeployContext();

        public TestController()
        {

        }

        [Route("settings")]
        [HttpGet]
        public IHttpActionResult Settings()
        {
            return Ok(ConfigurationManager.AppSettings["environment"]);
        }

        [Route("getAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(context.Persons.ToList());
        }

        [Route("get/{id}")]
        public IHttpActionResult Get(int id)
        {
            var person = context.Persons.Where(x => x.Id == id);
            return Ok(person);
        }

        [Route("add")]
        [HttpPost]
        public IHttpActionResult Add(Person person)
        {
            context.Persons.Add(person);
            context.SaveChanges();
            return Created("Add", person.Id);
        }
    }
}
