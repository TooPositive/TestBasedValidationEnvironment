using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Interfaces;

namespace InstanceMicroService.Instances
{
    public interface IInstance
    {
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public Task StartTest(ITest test);
        public Task Destroy();
        public Task Pause();

    }
}
