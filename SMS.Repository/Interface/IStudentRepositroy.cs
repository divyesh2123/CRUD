using SMS.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.Interface
{
    public interface IStudentRepositroy
    {
        bool AddStudentInfo(Student d);

        List<Student> GetAllStudents(); 
    }
}
