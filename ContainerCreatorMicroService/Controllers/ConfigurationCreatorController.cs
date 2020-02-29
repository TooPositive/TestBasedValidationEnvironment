using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigurationCreatorMicroService.Base;
using ConfigurationCreatorMicroService.Interfaces;
using ConfigurationCreatorMicroService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContainerCreatorMicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationCreatorController : ControllerBase
    {
        // GET: api/ConfigurationCreator
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ConfigurationCreator/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConfigurationCreator/Configuration
        [HttpPost]
        public void Post([FromBody] JsonResult jsonConfiguration)
        {
            var configuration = JsonConvert.DeserializeObject<Configuration>(jsonConfiguration.ToString()); // create dummy configuration instead of this for early tests
            var configurationCreatorService = new ConfigurationCreatorService(configuration);
            configurationCreatorService.Create();
        }

        // PUT: api/ConfigurationCreator/5
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
