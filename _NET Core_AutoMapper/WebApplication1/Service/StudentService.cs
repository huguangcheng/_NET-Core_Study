using IService;
using System;
using Model;
using AutoMapper;
using System.Collections.Generic;

namespace Service
{
    public class StudentService : IStudent
    {
        private IMapper _mapper;
        //构造注入automapper
        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public  int Exercise()
        {
            return 97;
        }

        public List<StudentView> getStudentInfo()
        {
            Student source = new Student() { Name="张国荣",Age=18};


            List<StudentView> destination = new List<StudentView>();



            _mapper.Map(source, destination);

            return destination;
        }
    }
}
