using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tests.Core.Dtos;
using Tests.Core.Interfaces;
using static Tests.Core.Base.Enums;

namespace Tests.Core.Base
{
    public abstract class BaseTest : ITest
    {
        public Guid Id { get; set; }
        public string PrettyTestNameSpace => TestNamespace.Substring(0, TestNamespace.IndexOf("Version=") - 2);
        public string TestNamespace { get; set; }
        private DateTime TestStartDate { get; set; }
        public TimeSpan Timeout { get; set; }
        public TimeSpan Duration { get; set; }
        public int Iterations { get; set; }
        public Results Result { get; set; }
        public Action TestFlow { get; set; }

        protected BaseTest(TimeSpan duration, int iterations)
        {
            this.TestNamespace = GetType().AssemblyQualifiedName;
            this.TestStartDate = DateTime.Now;
            Timeout = duration;
            Iterations = iterations;
        }

        public void RunTest()
        {
            try
            {
                for (int i = 0; i < Iterations; i++)
                    TestFlow.Invoke();

                Result = Results.Passed;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Test failed. {e.Message}");
                Result = Results.Failed;
            }
            OnTestEnd();
        }

        public void OnTestEnd()
        {
            Console.WriteLine("Sending result to api.");
            ApiConnector.PostAsync(Statics.TestMicroserviceUrl, Statics.TestResultApiEndPoint, CreateDto());
        }
        private TestResultDto CreateDto()
        {
            return new TestResultDto() { ExecutionTime = DateTime.Now, ResultName = Enum.GetName(typeof(Results), Result), Duration = DateTime.Now.Subtract(TestStartDate), TestId = Id, TestName = PrettyTestNameSpace };
        }
    }
}
