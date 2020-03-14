using MgrAngularWithDockers.Contracts;
using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public TestRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<TestResult> Get() => _applicationDbContext.TestResults.ToList();
    }
}
