using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContainerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tests.Base;
using static Tests.Base.Enums;

namespace ContainerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET: api/DockerTest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DockerTest/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/DockerTest/Run
        [HttpPost("Run")]
        public async Task PostRun([FromBody] JsonResult testEndResultJson)
        {
            var test = JsonConvert.DeserializeObject<BaseTest>(testEndResultJson.ToString());
            var testRunnerService = new TestRunnerService();
            await testRunnerService.RunTest(test);
        }

        // POST: api/DockerTest/TestEnd
        [HttpPost("TestEnd")]
        public void PostTestEnd([FromBody] JsonResult testEndResultJson)
        {
            var test = JsonConvert.DeserializeObject<BaseTest>(testEndResultJson.ToString());
            var testRunnerService = new TestRunnerService();
            testRunnerService.OnTestEnd(test);
        }

        // POST: api/DockerTest
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DockerTest/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
