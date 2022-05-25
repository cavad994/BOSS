using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOSS
{
    public class CV
    {
        public string Ixtisas { get; set; }
        public string School { get; set; }
        public double UnivercityScore { get; set; } = 0;
        public List<string> Skills { get; set; } = new();
        public List<string> Companies { get; set; } = new();
        public List<string> Languages { get; set; } = new();
        public bool Diplom { get; set; } = false;


        public CV()
        {
            Ixtisas = "";
            School = "";
            UnivercityScore = 0;
            Skills = new();
            Companies = new();
            Languages = new();
            Diplom = false;
        }




        #region Showing

        public void ShowSkills()
        {
            Console.WriteLine("\n\t\t\t\t\tSkills :");
            if (Skills.Count > 0)
            {
                foreach (var skill in Skills)
                {
                    Console.WriteLine("\t\t\t\t\t\t" + skill);
                }
            }
        }
        public void ShowCompanies()
        {
            Console.WriteLine("\n\t\t\t\t\tCompanies : ");
            if (Companies.Count > 0)
            {
                foreach (var company in Companies)
                {
                    Console.WriteLine("\t\t\t\t\t\t" + company);
                }
            }
        }
        public void ShowLanguages()
        {
            Console.WriteLine("\n\t\t\t\t\tLanguage :");
            if (Languages.Count > 0)
            {
                foreach (var language in Languages)
                {
                    Console.WriteLine("\t\t\t\t\t\t" + language);
                }
            }
        }

        public void ShowAllCW()
        {
            Console.WriteLine("\n\t\t\t\t\tIxtisas : " + Ixtisas);
            Console.WriteLine("\n\t\t\t\t\tSchool : " + School);
            Console.WriteLine("\n\t\t\t\t\tScore : " + UnivercityScore);
            ShowSkills();
            ShowCompanies();
            ShowLanguages();
            Console.WriteLine("\n\t\t\t\t\tSertificate : " + Diplom);
        }
        #endregion
    }
}
