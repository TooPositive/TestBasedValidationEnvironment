using MgrAngularWithDockers.Core.Repositories;
using MgrAngularWithDockers.Core.Models.db;

namespace MgrAngularWithDockers.Core.Services
{
    public class TestService : TestRepository
    {
        public TestService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
