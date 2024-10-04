using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Information
    {
        public void sum(EmployeeInfomration employeeInfomration1)
        {
            employeeInfomration1.Name = "Weltec";

        }

        public int sum(int a,int b)
        {
          return a + b;
        }
        public int div(int a, int b,out int c)
        {
            c = a / b;
            return a % b;
        }

    }
}
