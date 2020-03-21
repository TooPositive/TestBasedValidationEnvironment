using AutoMapper;
using MgrAngularWithDockers.Core.Dtos;
using MgrAngularWithDockers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Core.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TestResult, TestResultDto>()
                .ForMember(x => x.TestName, x => x.MapFrom(m => m.Test.TestNamespace));
            CreateMap<TestResultDto, TestResult>()
                .ForMember(x=> x.Test, x=> x.Ignore());
        }

    }
}
