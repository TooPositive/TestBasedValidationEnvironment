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

namespace IntegrationTests.Api
{
    [TestFixture]
    public class TestResultTest
    {
        private TestResultController _testResultController;
        private Mock<ITestResultService> _mockRepo;
        private Mock<ILogger<TestResultController>> _logger;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<ITestResultService>();
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
    }
}
