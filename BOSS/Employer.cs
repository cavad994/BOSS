using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// /////////////////////////////////////////////
/// ISHE GOTUREN
/// </summary>
namespace BOSS
{
    internal class Employer
    {
        public int IDe { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public int age { get; set; }
        public List<Work> Vacancies { get; set; }

        public Employer(int iDe, string name, string surname,
            string city, string number, int age)
        {
            IDe = iDe;
            Name = name;
            Surname = surname;
            City = city;
            Number = number;
            this.age = age;
            Vacancies = new List<Work>();
        }

        public void AddVacansie(Work work) { Vacancies.Add(work); }

        public void ShowVacansies() {
            for (int i = 0; i < Vacancies.Count; i++)
            {
                Console.WriteLine($"\n\t\t\t\t{(i+1)}) Name : " + Vacancies[i].Name);
                Console.WriteLine("\n\t\t\t\t\tDescription : " + Vacancies[i].Description);
                Console.WriteLine("\n\t\t\t\t\tSalary : " + Vacancies[i].Salary);

            }
        }

        

    }
}
