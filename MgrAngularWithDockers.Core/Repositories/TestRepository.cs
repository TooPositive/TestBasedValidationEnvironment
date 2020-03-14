using MgrAngularWithDockers.Interfaces;
using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Core.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        //public TestRepository(ApplicationDbContext applicationDbContext)
        //{
        //    _applicationDbContext = applicationDbContext;
        //}

        public IEnumerable<Test> Create(Test test)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TestResult> Get() => _applicationDbContext.TestResults.ToList();

        public IEnumerable<Test> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Test> ITestRepository.Get()
        {
            throw new NotImplementedException();
        }
    }
}
