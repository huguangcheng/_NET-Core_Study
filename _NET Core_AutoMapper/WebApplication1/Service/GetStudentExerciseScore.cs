using System;
using System.Collections.Generic;
using System.Text;
using IService;
using Model;

namespace Service
{
    class GetStudentExerciseScore : IStudent
    {
        public StudentView getStudentInfo()
        {
            throw new NotImplementedException();
        }
        public int GetExerciseScore()
        {
            return 2;
        }
    }
}
