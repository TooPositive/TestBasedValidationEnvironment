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
using AutoMapper;

namespace MgrAngularWithDockers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestResultController : ControllerBase
    {
        private readonly ILogger<TestResultController> logger;
        private readonly IRepository<TestResult> testResultRepository;
        private readonly IRepository<Test> testRepository;
        private readonly IMapper mapper;
         //private ITestResultService testResultService;

        public TestResultController(ILogger<TestResultController> logger, IRepository<TestResult> testResultRepo, IRepository<Test> testRepository, IMapper mapper)
        {
            testResultRepository = testResultRepo;
            this.testRepository= testRepository;
            this.mapper = mapper;
            //testResultService = new TestResultService();
        }

        [HttpPost]
        public StatusCodeResult PostNew(TestResultDto testResultDto)
        {
            
            var testResult = new TestResult() { Id = testResultDto.Id, Result = testResultDto.Result, Test = testRepository.GetById(testResultDto.TestId) };            
            testResultRepository.Create(testResult);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<TestResultDto> Filter()
        {
            return testResultRepository.Filter().ToList().Select(mapper.Map<TestResultDto>);

        }
    }
}
