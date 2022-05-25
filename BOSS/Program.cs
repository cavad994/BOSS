using System.Threading;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BOSS
{
    class Starts
    {

        static int IDemployer = 0;
        static int IDworker = 0;

        public void RegisterWorker(ref Base @base)
        {
            Console.WriteLine("\n\n\n\n\t\t\t\t\tPlease enter your name : ");
            string? newName = Console.ReadLine();

            Console.WriteLine("\t\t\t\t\tPlease enter your surname : ");
            string? newSurname = Console.ReadLine();

            Console.WriteLine("\t\t\t\t\tPlease enter your city : ");
            string? newCity = Console.ReadLine();

            Console.WriteLine("\t\t\t\t\tPlease enter your phone number : ");
            string? newNumber = Console.ReadLine();

            Console.WriteLine("\t\t\t\t\tPlease enter your age : ");
        num:
            int age = 0;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                goto num;
            }

            Worker worker = new(++IDworker, newName, newSurname, newCity, newNumber, age);
            worker.Cv = new();
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\tWorker succesfully added!");
            Thread.Sleep(3000);
            @base.workers.Add(worker);
            JsonWorkerSerialize(@base.workers);
        }
        public void RegisterEmployer(ref Base @base)
        {
            Console.WriteLine("\n\n\n\n\t\t\t\t\tPlease enter your name : ");
            string newName = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\tPlease enter your surname : ");
            string newSurname = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\tPlease enter your city : ");
            string newCity = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\tPlease enter your phone number : ");
            string newNumber = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\tPlease enter your age : ");
        num:
            int age = 0;
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                goto num;
            }

            Employer employer = new(++IDemployer, newName, newSurname, newCity, newNumber, age);
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t\t\t\tEmployer succesfully added!");
            Thread.Sleep(3000);
            @base.employers.Add(employer);
            JsonEmployerSerialize(@base.employers);
        }
        public void LogInEmployer(Employer employer, Base @base)
        {
        sifte:
            Console.Clear();
            Console.WriteLine($"\n\n\n\t\t\t\t\tHello Mr.{employer.Name}");
            Console.WriteLine("\n\n\t\t\t\t\t0 - LOG OUT");
            Console.WriteLine("\n\t\t\t\t\t1 - MY VACANCIES");
            Console.WriteLine("\n\t\t\t\t\t2 - SHOW WORKERS");
            int sifte = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
            Console.Clear();
            if (sifte == 0) { return; }
            else if (sifte == 1)
            {
            vacancies:
                Console.Clear();
                employer.ShowVacansies();
                Console.WriteLine("\n\t9 - Add vacance");
                Console.WriteLine("\t0 - Back");
                int choiceVacance = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                if (choiceVacance == 0) { goto sifte; }
                else if (choiceVacance == 9)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\t\t\tName : ");
                    string newWorkName = Console.ReadLine();
                    Console.WriteLine("\n\t\t\t\t\tDescription : ");
                    string newWorkDescrip = Console.ReadLine();
                salary:
                    Console.WriteLine("\n\t\t\t\t\tSalary : ");
                    try
                    {
                        int newWorkSalary = Convert.ToInt32(Console.ReadLine());
                        employer.AddVacansie(new Work(newWorkName, newWorkDescrip, newWorkSalary));
                    }
                    catch (FormatException ex)
                    {
                        goto salary;
                    }
                    JsonEmployerSerialize(@base.employers);
                    goto vacancies;
                }
                else if (choiceVacance > 0 && choiceVacance < employer.Vacancies.Count + 1)
                {
                    Console.WriteLine("\n\t\t\t\t\tSpace - DELETE VACANCE");
                    Console.WriteLine("\t\t\t\t\tPress any key to cancel");
                    char deleting = Console.ReadKey().KeyChar;
                    if (deleting == ' ')
                    {
                        employer.Vacancies.Remove(employer.Vacancies[choiceVacance - 1]);
                        JsonEmployerSerialize(@base.employers);
                        goto vacancies;
                    }
                    else
                    {
                        goto vacancies;
                    }
                }
                else
                    goto vacancies;

            }
            else if (sifte == 2)
            {
                int i = 0;
            dovr:
                if (@base.workers.Count != 0)
                {
                    @base.workers[i].ShowCV();
                    Console.WriteLine("You can change worker by keys 'a' and 'd'");
                    Console.WriteLine("If you want to work with him, press 'Space'!");
                    Console.WriteLine("If you want to leave, press '0'!");
                    char ch = Console.ReadKey().KeyChar;
                    bool b = false;
                    if (ch == 'd')
                    {
                        if (i == 0)
                            i = @base.workers.Count - 1;
                        else
                            i--;
                    }
                    else if (ch == 'a')
                    {
                        if (i == @base.workers.Count - 1)
                            i = 0;
                        else
                            i++;
                    }
                    else if (ch == '0') { goto sifte; }
                    else if (ch == ' ')
                    {
                        Console.Clear();
                        Console.WriteLine($"\n\n\n\n\t\t\t\t\t{@base.workers[i].Name} will work with you!");
                        Console.WriteLine($"\n\n\n\n\n\t\t\t\t\t\tGOOD LUCK!");
                        Thread.Sleep(3000);
                        @base.workers.Remove(@base.workers[i]);
                        JsonEmployerSerialize(@base.employers);
                        JsonWorkerSerialize(@base.workers);
                    }
                    Console.Clear();
                    goto dovr;
                }
                else
                {
                    Console.WriteLine("\n\n\n\n\t\t\t\t\tNo any workers!");
                    Thread.Sleep(2000);
                    goto sifte;
                }


            }
            else
            {
                goto sifte;
            }
        }
        public void LogInWorker(Worker worker, ref Base @base)
        {
        sifte:
            Console.Clear();
            Console.WriteLine($"\n\n\n\t\t\t\t\tHello Mr.{worker.Name}");
            Console.WriteLine("\n\n\t\t\t\t\t0 - LOG OUT");
            Console.WriteLine("\n\t\t\t\t\t1 - MY CV");
            Console.WriteLine("\n\t\t\t\t\t2 - SHOW VACANCIES");
            int sifte = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
            Console.Clear();
            if (sifte == 0) { return; }
            else if (sifte == 1)
            {
            mycv:
                worker.ShowCV();
                Console.WriteLine("1 - Change Ixtisas");
                Console.WriteLine("2 - Change School");
                Console.WriteLine("3 - Change Univercity Score");
                Console.WriteLine("4 - Add Skills");
                Console.WriteLine("5 - Add Companies");
                Console.WriteLine("6 - Add Languages");
                Console.WriteLine("7 - Sertificate");
                Console.WriteLine("Press anything else, to go back");
                int changing = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                if (Convert.ToInt32(changing) >= 1 && Convert.ToInt32(changing) <= 6)
                {
                newAdding:
                    Console.Clear();
                    Console.WriteLine("Enter new CV element : ");
                    string newAddedElement = Console.ReadLine();
                    if (newAddedElement != null)
                    {
                        if (changing == 1)
                            worker.Cv.Ixtisas = newAddedElement;
                        else if (changing == 2)
                            worker.Cv.School = newAddedElement;
                        else if (changing == 3)
                            try
                            {
                                worker.Cv.UnivercityScore = Convert.ToInt32(newAddedElement);
                            }
                            catch (Exception)
                            {
                                goto newAdding;
                            }
                        else if (changing == 4)
                            worker.Cv.Skills.Add(newAddedElement);
                        else if (changing == 5)
                            worker.Cv.Companies.Add(newAddedElement);
                        else if (changing == 6)
                            worker.Cv.Languages.Add(newAddedElement);
                        JsonWorkerSerialize(@base.workers);
                    }
                    else
                        goto mycv;

                }
                else if (changing == 7)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\t\t\t\t\tHave you got an sertificate?");
                    Console.WriteLine("\n\n\n\n\t\t\t\t\t1 - yes | 2 - no");
                    Console.WriteLine("\n\t\t\t\t\t");
                    int serti = Console.ReadKey().KeyChar;
                    if (Convert.ToInt32(serti) - 48 == 1)
                    {
                        worker.Cv.Diplom = true;
                    }
                    else if (Convert.ToInt32(serti) - 48 == 2)
                    {
                        worker.Cv.Diplom = false;
                    }
                    else
                        goto mycv;
                }
                goto sifte;
            }
            else if (sifte == 2)
            {
                bool b = false;
            vacance:
                for (int i = 0; i < @base.employers.Count; i++)
                {
                    Console.WriteLine("\t\t\t\t\t" + @base.employers[i].Name);
                    @base.employers[i].ShowVacansies();
                    Console.WriteLine("\n\t\t\t\t\tIf you agree with one of them, enter any index!\n" +
                        "\t\t\t\t\tIn other way, you can continue by any key" +
                        "\n\t\t\t\t\tTo go back enter '0'");
                    int vacan = Console.ReadKey().KeyChar - 48;
                    if (vacan == 0) { goto sifte; }
                    else if (vacan > 0 && vacan <= @base.employers[i].Vacancies.Count)
                    {
                        b = true;
                        Console.Clear();
                        Console.WriteLine($"\n\n\n\n\t\t\t\tUntil today, you are working as {@base.employers[i].Vacancies[vacan - 1].Name} to {@base.employers[i].Name}");
                        @base.employers[i].Vacancies.Remove(@base.employers[i].Vacancies[vacan - 1]);
                        Thread.Sleep(5000);
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        continue;
                    }
                }
                if (!b) { goto vacance; }

            }
            else
            {
                goto sifte;
            }
        }
        public void Start()
        {
            #region code

            //Work fehle = new("Fehle", "Bina tikintisi ucun fehle axtarilir. 9 saat is", 300);
            //Work satici = new("Satici", "Oba market ucun satici qiz axtarilir. 9 saat is", 400);
            //Work bank = new("Bankir", "Kapital bank ucun emekdas axtarilir. 9 saat is", 800);

            //Employer boss1 = new(++IDemployer, "Cavad", "Yusifzada", "Sheki", "0506335500", 19);
            //Employer boss2 = new(++IDemployer, "Ziyad", "Yusifzada", "Sheki", "0553030004", 17);

            //boss1.AddVacansie(bank);
            //boss1.AddVacansie(fehle);
            //boss2.AddVacansie(bank);

            //List<string> skills = new(); skills.Add("programming"); skills.Add("nurse");
            //List<string> companies = new();
            //List<string> languages = new(); languages.Add("Russian"); languages.Add("Turkish");

            //CV cvfazil = new("IT", "Fizika Riyaziyyat", 560, skills, companies, languages, true);
            //CV cvmemmed = new("IT", "Fizika Riyaziyyat", 560, skills, companies, languages, true);

            //Worker fazil = new(IDworker, "Fazil", "Fazilov", "Goranboy", "0501234567", 27, cvfazil);
            //Worker memmed = new(IDworker, "Memmed", "Fazilov", "Goranboy", "0501234567", 27, cvmemmed);

            //List<Worker> workers = new();
            //workers.Add(fazil);
            //workers.Add(memmed);

            //List<Employer> employers = new();
            //employers.Add(boss1);
            //employers.Add(boss2);

            //List<Work> works = new();
            //works.Add(fehle);
            //works.Add(satici);
            //works.Add(bank);

            //Base _base = new(employers, workers, works);
            #endregion
            Employer employer = null;
            Worker worker = null;
            Work work = null;
            List<Employer> employers = JsonEmployerDeserialize();
            List<Worker> workers = JsonWorkerDeserialize();
            List<Work> works = new();
            Base _base = new(employers, workers, works);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\t\t\t\t\tWelcome to the site!");
                Console.WriteLine("\n\n\t\t\t\t1 - LOG IN\n\n\t\t\t\t2 - REGISTER");
                int sechim = Convert.ToInt32(Console.ReadKey().KeyChar) - 48;
                if (sechim == 1)
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\t\t\t\t\tName : ");
                    string? name = Console.ReadLine();
                    if (name != null)
                    {
                        bool entered = false;
                        Console.WriteLine("\n\n\n\t\t\t\t\tSurname : ");
                        string? surname = Console.ReadLine();
                        for (int i = 0; i < _base.employers.Count; i++)
                        {
                            if (_base.employers[i].Name == name && _base.employers[i].Surname == surname)
                            {
                                entered = true;
                                LogInEmployer(_base.employers[i], _base);
                            }
                        }
                        for (int i = 0; i < _base.workers.Count; i++)
                        {
                            if (_base.workers[i].Name == name && _base.workers[i].Surname == surname)
                            {
                                entered = true;
                                LogInWorker(_base.workers[i], ref _base);
                            }
                        }
                        if (entered != true)
                        {
                            Console.Clear();
                            Console.WriteLine("\n\n\n\n\t\t\t\t\tNo any user!\n");
                            Thread.Sleep(1000);
                            Start();
                        }
                    }
                }

                if (sechim == 2)
                {
                registration:
                    Console.Clear();
                    Console.WriteLine("" +
                        "\n\n\n\n\t\t\t\t\t1 - As employer" +
                        "\n\t\t\t\t\t2 - As worker");
                    char registr = Console.ReadKey().KeyChar;
                    if (registr == '1')
                    {
                        RegisterEmployer(ref _base);
                        continue;
                    }
                    else if (registr == '2')
                    {
                        RegisterWorker(ref _base);
                        continue;
                    }
                    else { goto registration; }

                }
            }
        }

        //public void JsonBaseSerialize(Base bs)
        //{
        //    string jsonName = "base.json";
        //    string jsonstring = JsonSerializer.Serialize(bs);
        //    File.WriteAllText(jsonName, jsonstring);
        //}
        //public Base? JsonBaseDeserialize()
        //{
        //    string fileName = "base.json";
        //    if (File.Exists(fileName))
        //    {
        //        string jsonString = File.ReadAllText(fileName);
        //        Base? base_ = JsonSerializer.Deserialize<Base>(jsonString);
        //        return base_;
        //    }
        //    return null;
        //}
        public void JsonEmployerSerialize(List<Employer> emp)
        {
            string jsonName = "employers.json";
            dynamic jsonstring = JsonConvert.SerializeObject(emp, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonName, jsonstring);
        }
        public List<Employer>? JsonEmployerDeserialize()
        {
            string fileName = "employers.json";
            if (File.Exists(fileName))
            {
                var jsonString = File.ReadAllText(fileName);
                List<Employer>? employers = JsonConvert.DeserializeObject<List<Employer>>(jsonString.Normalize());
                return employers;
            }
            return new();
        }
        
        public void JsonWorkerSerialize(List<Worker> workers)
        {
            string jsonName = "workers.json";
            var jsonstring = JsonConvert.SerializeObject(workers);
            File.WriteAllText(jsonName, jsonstring);
        }
        public List<Worker>? JsonWorkerDeserialize()
        {
            string fileName = "workers.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<Worker>? workers = JsonConvert.DeserializeObject<List<Worker>>(jsonString);
                return workers;
            }
            return new();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Starts starts = new Starts();
            starts.Start();
        }
    }
}