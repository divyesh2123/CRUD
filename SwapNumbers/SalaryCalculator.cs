using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapNumbers
{
    public class SalaryCalculator
    {
        public int numberofHours;

        public int payrate;

        public void input()
        {
            Console.WriteLine("Please enter hours you worked");

            numberofHours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter payrate");

            payrate = Convert.ToInt32(Console.ReadLine());

        }

        public void output()
        {
            Console.WriteLine($"Total Pay {payrate * numberofHours}");

        }

    }
}
