using MgrAngularWithDockers.Core.Generics;
using System;
using static Tests.Core.Base.Enums;

namespace MgrAngularWithDockers.Core.Models.Interfaces
{
    public interface ITestResult : IEntity
    {
        public Guid Id { get; set; }
        public Results Result { get; set; }
        public DateTime ExecutionTime { get; set; }
        public Guid TestId { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
