using System;
using System.Threading.Tasks;

namespace Tests.Core.Interfaces
{
    public interface ITest
    {
        public Guid Id { get; set; }
        public string TestNamespace { get; set; }
        public TimeSpan Timeout { get; set; }
        public int Iterations { get; set; }
    }
}
