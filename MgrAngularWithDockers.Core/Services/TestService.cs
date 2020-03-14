using MgrAngularWithDockers.Core.Services.Interfaces;
using MgrAngularWithDockers.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MgrAngularWithDockers.Models.db;

namespace MgrAngularWithDockers.Core.Services
{
    public class TestService : TestRepository
    {
        public TestService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
