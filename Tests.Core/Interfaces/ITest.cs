using System;
using System.Threading.Tasks;

namespace Tests.Core.Interfaces
{
    public interface ITest
    {
        Guid Id { get; set; }
        //string TestNamespace { get; set; }
        TimeSpan Duration { get; set; }
        int Iterations { get; set; }
    }
}
