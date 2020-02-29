using ConfigurationCreatorMicroService.Base;
using ConfigurationCreatorMicroService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;
using static ConfigurationCreatorMicroService.Statics.Enums;

namespace ConfigurationCreatorMicroService.Services
{
    public class ConfigurationCreatorService
    {
        public string Name { get; set; }
        public Configuration Configuration { get; set; }
        public IEnviroment Enviroment { get; set; }

        public ConfigurationCreatorService(Configuration configuration)
        {
            Configuration = configuration;
            switch (configuration.EnviromentType)
            {
                case EnviromentType.Docker:
                    Enviroment = new BaseDockerEnviroment();
                    break;
                case EnviromentType.VirtualBox:
                    Enviroment = new BaseVirtualBoxEnviroment();
                    break;
                default:
                    throw new Exception("Cannot identify creator service.");
            }
        }

        public void Create()
        {
            Enviroment.Create();
        }

        public void Destroy()
        {
            Enviroment.Destroy();
        }

        public void Pause()
        {
            Enviroment.Pause();
        }

        public void RunTest(BaseTest test)
        {
            Enviroment.RunTest(test);
        }
    }
}
