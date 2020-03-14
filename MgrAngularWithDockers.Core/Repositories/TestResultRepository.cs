using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Interfaces;
using MgrAngularWithDockers.Models;
using MgrAngularWithDockers.Models.db;
using System;
using System.Collections.Generic;
using System.Text;

namespace MgrAngularWithDockers.Core.Repositories
{
    public class TestResultRepository : Repository<TestResult>
    {
        public TestResultRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
