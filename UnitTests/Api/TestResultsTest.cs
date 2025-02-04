﻿using MgrAngularWithDockers.Models;
using Moq;
using System;
using System.Collections.Generic;
using NUnit.Framework;
using MgrAngularWithDockers.Controllers;
using System.Linq;
using Microsoft.Extensions.Logging;
using MgrAngularWithDockers.Core.Generics;
using Tests.Core.Simple;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MgrAngularWithDockers.Core.Extensions;
using Tests.Core.Dtos;

namespace IntegrationTests.Core.Api
{
    [TestFixture]
    public class TestResultTest
    {
        private TestResultController _testResultController;
        private Mock<IRepository<TestResult>> _mockTestResultRepo;
        private Mock<IRepository<Test>> _mockTestRepo;
        private Mock<ILogger<TestResultController>> _logger;

        [SetUp]
        public void SetUp()
        {
            _mockTestResultRepo = new Mock<IRepository<TestResult>>();
            _mockTestRepo = new Mock<IRepository<Test>>();
            _logger = new Mock<ILogger<TestResultController>>();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _testResultController = new TestResultController(_logger.Object, _mockTestResultRepo.Object, _mockTestRepo.Object, mapper);
        }

        [Test]
        public void GetAllTestResults()
        {
            _mockTestResultRepo.Setup(repo => repo.Filter()).Returns(new List<TestResult>() { new TestResult(), new TestResult() });

            var result = _testResultController.Filter();
            Assert.IsTrue(result is IEnumerable<TestResultDto>);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void PostNewTestResult()
        {
            var test = new SimpleIOCheckTest() { Id = new Guid(), Timeout = new TimeSpan(5, 0, 0), Iterations = 1 };
            var result = new TestResultDto() { Id = new Guid(), TestId = test.Id, ResultName = Enum.GetName(typeof(Tests.Core.Base.Enums.Results), Tests.Core.Base.Enums.Results.Passed) };

            var apiResult = _testResultController.PostNew(result);
            Assert.AreEqual(apiResult.StatusCode, new OkResult().StatusCode);

        }
    }
}
