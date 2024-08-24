using SMS.BussinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BussinessService.Interface
{
    public interface IStudentService
    {
        bool AddStudentInfo(StudentViewModel d);

        public List<StudentViewModel> GetAllStudents();
    }
}
