using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace MgrAngularWithDockers.Core.Dtos
{
    public class TestResultDto
    {
        public Guid Id { get; set; }
        public Results Result { get; set; }
        public Guid TestGuid { get; set; }
    }
}
