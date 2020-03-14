using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Tests.Base.Enums;

namespace MgrAngularWithDockers.Models
{
    public class TestResult
    {
        [Key]
        public Guid Guid { get; set; }
        public Results Result { get; set; }    
        [ForeignKey("Test")]
        public Guid TestGuid { get; set; }
        public virtual Test Test { get; set; }
    }
}
