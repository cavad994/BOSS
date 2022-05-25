using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS
{
    internal class Work
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }


        public Work(string name, string description, int salary)
        {
            Name = name;
            Description = description;
            Salary = salary;
        }


    }
}
