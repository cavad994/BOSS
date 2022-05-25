using System;

namespace BOSS
{
    internal class Worker
    {
        public int IDw { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public int Age { get; set; }
        public CV Cv { get; set; }

        public Worker(int ıD, string name, string surname,
            string city, string number, int age)
        {
            this.IDw = ıD;
            this.Name = name;
            this.Surname = surname;
            this.City = city;
            this.Number = number;
            this.Age = age;
            CV cV = new CV();
        }

        public void ShowCV()
        {
            Console.WriteLine("\n\n\n\t\t\t\t\tName : " + Name);
            Console.WriteLine("\n\t\t\t\t\tSurname : " + Surname);
            Console.WriteLine("\n\t\t\t\t\tAge : " + Age);
            Cv.ShowAllCW();
        }
    }
}
