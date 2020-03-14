using MgrAngularWithDockers.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MgrAngularWithDockers.Controllers;
using MgrAngularWithDockers.Contracts;
using System.Linq;

namespace IntegrationTests.Api
{
    [TestFixture]
    public class TestResultTest
    {
        private TestResultController _testResultController;
        private Mock<ITestResultRepository> _mockRepo;

        [SetUp]
        public void SetUp()
        {
            _mockRepo = new Mock<ITestResultRepository>();
            _testResultController = new TestResultController(_mockRepo.Object);
        }

        [Test]
        public void GetAllTestResults()
        {
            _mockRepo.Setup(repo => repo.Get()).Returns(new List<TestResult>() { new TestResult(), new TestResult() });

            var result = _testResultController.Get();
            Assert.IsTrue(result is IEnumerable<TestResult>);
            Assert.AreEqual(2, result.Count());
        }
    }
}
