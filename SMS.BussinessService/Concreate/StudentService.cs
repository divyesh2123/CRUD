using SMS.BussinessEntity;
using SMS.BussinessService.Interface;
using SMS.Common;
using SMS.Repository.Concreate;
using SMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BussinessService.Concreate
{
    public class StudentService : IStudentService
    {
        private IStudentRepositroy studentRepositroy;
        public StudentService()
        {
            studentRepositroy = new StudentRepositroy();
        }

        public bool AddStudentInfo(StudentViewModel d)
        {

           return studentRepositroy.AddStudentInfo(d.ToDataModel());
        }

        public List<StudentViewModel> GetAllStudents()
        {
            return studentRepositroy.GetAllStudents().ToViewModel();
        }
    }
}
