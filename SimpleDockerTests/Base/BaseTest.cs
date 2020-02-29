using Tests.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace Tests.Base
{
    public abstract class BaseTest : ITest
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Iterations { get; set; }
        public TestResult TestResult { get; set; }
        public Func<Task> TestFlow { get; set; }

        protected BaseTest(string name, TimeSpan duration, int iterations)
        {
            Name = name;
            Duration = duration;
            Iterations = iterations;
        }

        public async Task RunTest()
        {
            try
            {
                for (int i = 0; i < Iterations; i++)
                    await TestFlow.Invoke();

                TestResult = TestResult.Passed;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test failed. {e.Message}");
                TestResult = TestResult.Failed;
            }
            await OnTestEnd();
        }

        public async Task OnTestEnd()
        {
            Console.WriteLine("Sending result to api.");
            await ApiConnector.CallServiceAsync<HttpResponse>(Statics.TestMicroserviceUrl, this, HttpMethods.Post);
        }
    }
}
