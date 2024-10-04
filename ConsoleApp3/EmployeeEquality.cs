using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class EmployeeEquality : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return x.Name == y.Name && x.Id == y.Id;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.GetHashCode();
        }
    }
}
