using MgrAngularWithDockers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Interfaces
{
    public interface ITestRepository 
    {
        IEnumerable<Test> Get();
        IEnumerable<Test> Get(Guid id);
        IEnumerable<Test> Create(Test test);
    }
}
