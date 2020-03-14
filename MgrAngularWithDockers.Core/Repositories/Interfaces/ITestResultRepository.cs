using MgrAngularWithDockers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Interfaces
{
    public interface ITestResultRepository
    {
        IEnumerable<TestResult> Get();
        IEnumerable<TestResult> Get(Guid id);
        IEnumerable<TestResult> Create(TestResult testResult);
    }
}
