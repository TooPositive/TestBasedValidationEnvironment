using MgrAngularWithDockers.Core.Generics;
using MgrAngularWithDockers.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace MgrAngularWithDockers.Models
{
    public class TestResult : ITestResult
    {

        [Key]
        public Guid Id { get; set; }
        public Results Result { get; set; }
        [ForeignKey("Test")]
        public Guid TestGuid { get; set; }
        public virtual Test Test { get; set; }
    }
}
