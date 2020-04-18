﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tests.Core.Base.Enums;

namespace Tests.Core.Dtos
{
    public class TestResultDto
    {
        public Guid Id { get; set; }
        public string ResultName { get; set; }
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public DateTime ExecutionTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
