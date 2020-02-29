using ConfigurationCreatorMicroService.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Base;
using static ConfigurationCreatorMicroService.Statics.Enums;

namespace ConfigurationCreatorMicroService.Interfaces
{
    public interface IEnviroment
    {
        public string Name { get; set; }
        public Configuration Configuration { get; set; }
        public Task Create();
        public Task RunTest(BaseTest test);
        public Task Pause();
        public Task Destroy();


    }
}
