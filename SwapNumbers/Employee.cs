using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//data en
namespace SwapNumbers
{
    public class Employee
    {
       public string employeeId;
        string name;

        
       
            
        //public is access modifier
        // void is return type
        public void Input()
        {
            Console.WriteLine("Please enter employeeId");
            employeeId = Console.ReadLine();

            Console.WriteLine("please Enter Name");
            name = Console.ReadLine();  



        }

        public void Display()
        {
            Console.WriteLine(employeeId);
            Console.WriteLine(name);    

        }
       
    }
}
