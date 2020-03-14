using MgrAngularWithDockers.Interfaces;
using MgrAngularWithDockers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgrAngularWithDockers.Core.Repositories
{
    public class TestResultRepository : ITestResultRepository
    {
        public IEnumerable<TestResult> Create(TestResult testResult)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
