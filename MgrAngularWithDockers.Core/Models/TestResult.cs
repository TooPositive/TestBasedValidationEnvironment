using MgrAngularWithDockers.Core.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Tests.Core.Base.Enums;

namespace MgrAngularWithDockers.Models
{
    public class TestResult : ITestResult
    {

        [Key]
        public Guid Id { get; set; }
        public Results Result { get; set; }
        public DateTime ExecutionTime { get; set; }
        public TimeSpan Duration { get; set; }

        [ForeignKey("Test")]
        public Guid TestId { get; set; }
        public virtual Test Test { get; set; }
    }
}
