using System;
using static ConfigurationCreatorMicroService.Statics.Enums;

namespace ConfigurationCreatorMicroService.Base
{
    public abstract class Configuration
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public EnviromentType EnviromentType { get; set; }
    }
}