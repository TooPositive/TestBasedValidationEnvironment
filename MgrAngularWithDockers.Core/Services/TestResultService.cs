using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Core.Models.Interfaces;
using MgrAngularWithDockers.Core.Repositories;
using MgrAngularWithDockers.Core.Services.Interfaces;
using MgrAngularWithDockers.Models.db;
using  System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Core.Services
{
    public class TestResultService : TestResultRepository, ITestResultService
    {
        public TestResultService(ApplicationDbContext context) : base(context)
        {
        }

        public void Create(ITestResult entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ITestResult entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(ITestResult entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITestResult> Filter(Expression<Func<ITestResult, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ITestResult> IRepository<ITestResult>.Filter()
        {
            throw new NotImplementedException();
        }

        ITestResult IRepository<ITestResult>.GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
