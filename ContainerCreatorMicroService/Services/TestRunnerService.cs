using InstanceMicroService.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Interfaces;

namespace InstanceMicroService.Services
{
    public class TestRunnerService
    {
        private IInstance instance { get; set; }

        public TestRunnerService(IInstance instance)
        {
            this.instance = instance;
        }

        public async Task StartTest(ITest test)
        {
            Console.WriteLine("Starting test.");
            await instance.StartTest(test);
        }

        //public async Task OnStartTest()
        //{
        //    Console.WriteLine("On test start.");
        //}
    }
}
