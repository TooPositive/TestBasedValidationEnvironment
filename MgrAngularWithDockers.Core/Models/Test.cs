﻿using MgrAngularWithDockers.Core.Generics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Core.Base;
using Tests.Core.Interfaces;

namespace MgrAngularWithDockers.Models
{
    public class Test : ITest, IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string TestNamespace { get; set; }
        public TimeSpan Timeout { get; set; }
        public int Iterations { get; set; }

        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}
