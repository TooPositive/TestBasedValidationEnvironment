using MgrAngularWithDockers.Core.Generics;
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
    public class TestRepository : Repository<Test>
    {
        public TestRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
