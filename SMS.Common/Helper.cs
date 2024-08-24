using SMS.BussinessEntity;
using SMS.Database;

namespace SMS.Common
{
    public static class Helper
    {
        public static Student ToDataModel(this StudentViewModel studentViewModel)
        {
            Student student = new Student();
            student.Address = studentViewModel.Address;
            student.FirstName = studentViewModel.FirstName;
            student.LastName = studentViewModel.LastName;
            student.Email = studentViewModel.Email;
            student.Mobile = studentViewModel.Mobile;
            return student;
        }

        public static StudentViewModel ToViewModel(this Student studentViewModel)
        {
            StudentViewModel student = new StudentViewModel();  
            student.Address = studentViewModel.Address;
            student.FirstName = studentViewModel.FirstName;
            student.LastName = studentViewModel.LastName;   
            student.Email= studentViewModel.Email;  
            student.Mobile = studentViewModel.Mobile;
            return student;

        }

        public static List<StudentViewModel> ToViewModel(this List<Student> studentViewModel)
        {
            
            return studentViewModel.Select(y=>y.ToViewModel()).ToList();    

        }
    }
}
        
