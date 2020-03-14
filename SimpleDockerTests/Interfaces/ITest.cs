using Tests.Base;
using System;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace Tests.Interfaces
{
    public interface ITest
    {
        Guid Id { get; set; }
        string TestNamespace { get; set; }
        TimeSpan Duration { get; set; }
        int Iterations { get; set; }
    }
}
