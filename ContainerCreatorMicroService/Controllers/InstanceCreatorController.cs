using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstanceMicroService.Instances;
using InstanceMicroService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tests.Core.Interfaces;
using Tests.Core.Simple;

namespace InstanceMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstanceCreatorController : ControllerBase
    {
        // GET: api/InstanceCreatorController
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/InstanceCreatorController/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(int id)
        {
            var xx = new DockerInstance();
            await xx.StartTest(new SimpleIOCheckTest());
            return "value";
        }

        // POST: api/InstanceCreatorController/Configuration
        [HttpPost]
        public async Task Post([FromBody] JsonResult jsonITest)
        {
            var test = JsonConvert.DeserializeObject<ITest>(jsonITest.ToString()); // create dummy configuration instead of this for early tests
            var instance = JsonConvert.DeserializeObject<IInstance>(jsonITest.ToString()); 
            var InstanceCreatorControllerService = new TestRunnerService(instance);
            await InstanceCreatorControllerService.StartTest(test);
        }

        // PUT: api/InstanceCreatorController/5
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
