using MgrAngularWithDockers.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MgrAngularWithDockers.Controllers;
using MgrAngularWithDockers.Interfaces;
using System.Linq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using MgrAngularWithDockers.Core.Services.Interfaces;
using MgrAngularWithDockers.Core.Generics;
using Tests.Simple;
using MgrAngularWithDockers.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTests.Api
{
    [TestFixture]
    public class TestResultTest
    {
        private TestResultController _testResultController;
        private Mock<IRepository<TestResult>> _mockRepo;
        private Mock<ILogger<TestResultController>> _logger;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<IRepository<TestResult>>();
            _logger = new Mock<ILogger<TestResultController>>();
            _testResultController = new TestResultController(_logger.Object, _mockRepo.Object);
        }

        [Test]
        public void GetAllTestResults()
        {
            _mockRepo.Setup(repo => repo.Filter()).Returns(new List<TestResult>() { new TestResult(), new TestResult() });

            var result = _testResultController.Filter();
            Assert.IsTrue(result is IEnumerable<TestResult>);
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public void PostNewTestResult()
        {
            var test = new SimpleIOCheckTest() { Id = new Guid(), Duration = new TimeSpan(5, 0, 0), Iterations = 1 };
            var result = new TestResultDto() { Id = new Guid(), TestGuid = test.Id, Result = Tests.Base.Enums.Results.Passed };

            var apiResult = _testResultController.PostNew(result);
            Assert.AreEqual(apiResult.StatusCode, new OkResult().StatusCode);

        }
    }
}
