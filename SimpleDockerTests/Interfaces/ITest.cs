using Tests.Base;
using System;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace Tests.Interfaces
{
    public interface ITest
    {
        string Name { get; set; }
        TimeSpan Duration { get; set; }
        int Iterations { get; set; }
        TestResult TestResult { get; set; }
        Func<Task> TestFlow { get; set; }
        Task RunTest();
        Task OnTestEnd();
    }
}
