using MgrAngularWithDockers.Core.Repositories;
using MgrAngularWithDockers.Core.Services.Interfaces;
using  System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Core.Services
{
    public class TestResultService : TestResultRepository, ITestResultService
    {
    }
}
