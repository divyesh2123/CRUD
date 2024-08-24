using SMS.Database;
using SMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Repository.Concreate
{
    public class StudentRepositroy : IStudentRepositroy
    {
        private  ADOEveningBatchContext aDOEveningBatchContext;
        public StudentRepositroy()
        {
            aDOEveningBatchContext = new ADOEveningBatchContext();
        }
        public bool AddStudentInfo(Student d)
        {
            aDOEveningBatchContext.Students.Add(d);
           return aDOEveningBatchContext.SaveChanges() > 0 ? true : false; ;
        }

        public List<Student> GetAllStudents()
        {
           return aDOEveningBatchContext.Students.ToList();
        }
    }
}
