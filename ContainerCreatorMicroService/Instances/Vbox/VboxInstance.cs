using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tests.Interfaces;

namespace InstanceMicroService.Instances
{
    public class VboxInstance : IVboxInstance
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        
        public Task Destroy()
        {
            throw new NotImplementedException();
        }

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public Task StartTest(ITest test)
        {
            throw new NotImplementedException();
        }
    }
}
