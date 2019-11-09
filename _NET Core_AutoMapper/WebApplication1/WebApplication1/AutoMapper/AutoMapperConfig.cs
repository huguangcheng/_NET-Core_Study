using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Model;
namespace WebApplication1
{
    class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Student, StudentView>().ForMember(d => d.StudentName, o => o.MapFrom(a => a.Name))
                .ForMember(d => d.Age, o => o.Ignore());
        }
    }
}
