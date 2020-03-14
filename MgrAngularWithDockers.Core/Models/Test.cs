using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;
using Tests.Interfaces;

namespace MgrAngularWithDockers.Models
{
    public class Test : ITest
    {
        [Key]
        public Guid Guid { get; set; }
        public string TestNamespace { get; set; }
        public TimeSpan Duration { get; set; }
        public int Iterations { get; set; }

        public virtual TestResult TestResult { get; set; }
    }
}
