using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Core.Models.db;
using MgrAngularWithDockers.Models;

namespace MgrAngularWithDockers.Core.Repositories
{
    public class TestRepository : Repository<Test>
    {
        public TestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
