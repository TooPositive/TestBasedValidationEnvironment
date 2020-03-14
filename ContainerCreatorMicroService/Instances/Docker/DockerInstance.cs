using InstanceMicroService.Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Interfaces;
using Docker.DotNet;

namespace InstanceMicroService.Instances
{
    public class DockerInstance : IDockerInstance
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
            DockerClient client = new DockerClientConfiguration(new Uri("tcp://your-docker-host:4243"), null).CreateClient();
            throw new NotImplementedException();
        }
    }
}
