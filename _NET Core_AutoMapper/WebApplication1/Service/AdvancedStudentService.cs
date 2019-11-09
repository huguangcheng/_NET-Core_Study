using IService;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class AdvancedStudentService : IStudent
    {
        //新增培优班的实现方法，现在需要将实现类替换成此类。
        //这是有新的需求，需要改变它的实现。
        public StudentView getStudentInfo()
        {
            return new StudentView() { StudentName="周星驰",Age=23};
        }
    }
}
