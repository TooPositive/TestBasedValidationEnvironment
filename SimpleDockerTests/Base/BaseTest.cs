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
        public Guid Guid { get; set; }
        public string TestNamespace { get; set; }
        public TimeSpan Duration { get; set; }
        public int Iterations { get; set; }
        public Results Results { get; set; }
        public Action TestFlow { get; set; }

        protected BaseTest(string testNamespace, TimeSpan duration, int iterations)
        {
            TestNamespace = testNamespace;
            Duration = duration;
            Iterations = iterations;
        }

        public void RunTest()
        {
            try
            {
                for (int i = 0; i < Iterations; i++)
                    TestFlow.Invoke();

                Results = Results.Passed;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test failed. {e.Message}");
                Results = Results.Failed;
            }
            OnTestEnd();
        }

        public void OnTestEnd()
        {
            Console.WriteLine("Sending result to api.");
            ApiConnector.CallServiceAsync<HttpResponse>(Statics.TestMicroserviceUrl, this, HttpMethods.Post);
        }
    }
}
