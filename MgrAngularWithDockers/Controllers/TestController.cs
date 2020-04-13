using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Interfaces;
using MgrAngularWithDockers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Interfaces;

namespace MgrAngularWithDockers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IRepository<Test> testRepository;
        public TestController(ILogger<TestController> logger, IRepository<Test> testRepo)
        {
            this._logger = logger;
            this.testRepository = testRepo;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<ITest> Filter()
        {
            var xx = testRepository.Filter().ToList();
            return xx;
        }


    }
}
