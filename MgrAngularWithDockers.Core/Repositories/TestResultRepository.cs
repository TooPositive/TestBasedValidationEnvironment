using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Core.Models.db;
using MgrAngularWithDockers.Models;

namespace MgrAngularWithDockers.Core.Repositories
{
    public class TestResultRepository : Repository<TestResult>
    {
        public TestResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
