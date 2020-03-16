using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MgrAngularWithDockers.Core.Services.Interfaces;
using MgrAngularWithDockers.Core.Models.Interfaces;
using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Core.Services;
using MgrAngularWithDockers.Core.Dtos;
using Microsoft.AspNetCore.Http;

namespace MgrAngularWithDockers.Controllers
{
    public class TestResultController : ControllerBase
    {
        private readonly ILogger<TestResultController> logger;
        private readonly IRepository<TestResult> testResultRepository;
         //private ITestResultService testResultService;

        public TestResultController(ILogger<TestResultController> logger, IRepository<TestResult> testResultRepo)
        {
            testResultRepository = testResultRepo;
            //testResultService = new TestResultService();
        }

        [HttpPost]
        public StatusCodeResult PostNew(TestResultDto testResultDto)
        {
            var testResult = new TestResult() { Id = testResultDto.Id, Result = testResultDto.Result, TestGuid = testResultDto.TestGuid };            
            testResultRepository.Create(testResult);
            return Ok();
        }

        [HttpGet]
        public IEnumerable<ITestResult> Filter()
        {
            return testResultRepository.Filter();
        }
    }
}
