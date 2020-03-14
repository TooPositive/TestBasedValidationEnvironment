using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;
using Tests.Interfaces;
using static Tests.Base.Enums;

namespace MgrAngularWithDockers.Models
{
    public class Test : ITest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TestNamespace { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int Iterations { get; set; }
    }
}
