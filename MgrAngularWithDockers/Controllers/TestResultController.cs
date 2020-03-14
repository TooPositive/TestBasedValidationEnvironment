using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MgrAngularWithDockers.Core.Services.Interfaces;

namespace MgrAngularWithDockers.Controllers
{
    public class TestResultController : ControllerBase
    {
        private readonly ILogger<TestResultController> logger;
        private readonly ITestResultService testResultService;

        public TestResultController(ILogger<TestResultController> logger, ITestResultService testResultService)
        {
            this.testResultService = testResultService;
        }

        [HttpGet]
        public IEnumerable<TestResult> Get()
        {
            return testResultService.Get();
        }
    }
}
