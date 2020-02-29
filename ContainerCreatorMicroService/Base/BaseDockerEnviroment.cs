using ConfigurationCreatorMicroService.Base;
using ConfigurationCreatorMicroService.Interfaces;
using System;
using System.Threading.Tasks;
using Tests.Base;
using static ConfigurationCreatorMicroService.Statics.Enums;

namespace ConfigurationCreatorMicroService.Base
{
    public class BaseDockerEnviroment : IEnviroment
    {
        public string Name { get; set; }
        public EnviromentType EnviromentType { get; set; }
        public Configuration Configuration { get; set; }

        public async Task Create()
        {
            throw new NotImplementedException();
        }

        public async Task Destroy()
        {
            throw new NotImplementedException();
        }

        public async Task Pause()
        {
            throw new NotImplementedException();
        }

        public async Task RunTest(BaseTest test)
        {
            await test.RunTest();
        }
    }
}
