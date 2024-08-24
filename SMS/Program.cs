
using SMS.BussinessEntity;
using SMS.BussinessService.Concreate;
using SMS.BussinessService.Interface;

bool isTerminated = true;
IStudentService obj = new StudentService();
do
{
    Console.WriteLine("Please select from below options");
    Console.WriteLine("1. For Add");
    Console.WriteLine("2 For Delete");
    Console.WriteLine("3 for Display");
    Console.WriteLine("5 for termination");
    Console.WriteLine("Please Enter choi");
   
    int ch = Convert.ToInt32(Console.ReadLine());
    switch(ch)
    {
        case 1:

            StudentViewModel jk = new StudentViewModel();
            Console.WriteLine("Please Enter FirstName");
            jk.FirstName = Console.ReadLine();

            Console.WriteLine("Please Enter LastName");
            jk.LastName = Console.ReadLine();


            Console.WriteLine("Please Enter Email");
            jk.Email = Console.ReadLine();

            Console.WriteLine("Please Enter Mobile");
            jk.Mobile = Console.ReadLine();

            Console.WriteLine("Please Enter Address");
            jk.Address = Console.ReadLine();

            obj.AddStudentInfo(jk);
            break;

        case 3:

            var data = obj.GetAllStudents();

            foreach(var d in data)
            {
                Console.Write(d.Address);
                Console.Write(d.FirstName);
                Console.Write(d.LastName);
                Console.WriteLine();
            }

            break;

        case 5:
            isTerminated = false;
            break;

    }

}while (isTerminated);