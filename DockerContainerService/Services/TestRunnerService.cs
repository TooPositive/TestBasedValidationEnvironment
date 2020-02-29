using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Base;
namespace ContainerService.Services
{
    public class TestRunnerService
    {
        public async Task RunTest(BaseTest test)
        {
            await test.RunTest(); // schedule run on given configuration
            // stuff
        }

        public void OnTestEnd(BaseTest test)
        {
            // stuff
        }
    }
}

