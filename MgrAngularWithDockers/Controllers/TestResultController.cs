using MgrAngularWithDockers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using MgrAngularWithDockers.Core.Generics;
using AutoMapper;
using Microsoft.AspNet.OData;
using Tests.Core.Dtos;
using static Tests.Core.Base.Enums;
using System;

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
            var testResult = new TestResult() { Id = testResultDto.Id, Result = (Results)Enum.Parse(typeof(Results), testResultDto.ResultName), Test = testRepository.GetById(testResultDto.TestId), ExecutionTime = testResultDto.ExecutionTime, Duration = testResultDto.Duration};            
            testResultRepository.Create(testResult);
            testResultRepository.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [EnableQuery]
        [Route("[action]")]
        public IEnumerable<TestResultDto> Filter()
        {
            return testResultRepository.Filter().ToList().Select(mapper.Map<TestResultDto>);

        }
    }
}

