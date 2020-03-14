using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Controllers
{
    public class TestResultController : ControllerBase
    {
        private readonly ILogger<TestResultController> _logger;
        private readonly ITestResultRepository _testRepository;
        public TestResultController(ILogger<TestResultController> logger)
        {
            this._logger = logger;
        }

        public TestResultController(ITestResultRepository testResultRepository)
        {
            this._testRepository = testResultRepository;
        }

        [HttpGet]
        public IEnumerable<TestResult> Get()
        {
            return new List<TestResult>();
                //_testRepository.Get();
        }
    }
}
