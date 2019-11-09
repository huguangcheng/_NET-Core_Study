using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Model;
namespace Service
{
    class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Student, StudentView>();
        }
    }
}
