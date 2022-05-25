using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace BOSS
{
    internal class Base
    {

        public List<Employer> employers { get; set; }
        public List<Worker> workers { get; set; }
        public List<Work> works { get; set; }

        public Base(List<Employer> employers, List<Worker> workers, List<Work> works)
        {
            this.employers = employers;
            this.workers = workers;
            this.works = works;
        }

        public void ShowWorkers()
        {
            foreach (var worker in workers)
            {
                Console.WriteLine(worker.IDw + ") " +worker.Name);
                Console.WriteLine("Age : " + worker.Age);
                Console.WriteLine("Region : " + worker.City);
            }
        }
        
    }
}
