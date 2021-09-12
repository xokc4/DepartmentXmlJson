using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace DepartmentXmlJson
{
    class Program
    {
        /// <summary>
        /// есть два путя , один путь к файлу xml, а второй путь к файлу json
        /// также открывает метод по выбору действий с файлами
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string path = @"C:\Новая папка\serealize.xml";// путь к папке xml
            string psth = @"C:\Новая папка\serealize.Json";// путь к папке Json
            Beginning(path, psth);// начала работы метода

            Console.ReadKey();
        }
        /// <summary>
        ///  В Beginning происходит выбор по добавлению , удалению и создания департамента с помощью switch
        /// </summary>
        /// <param name="path">файл xml</param>
        /// <param name="psth">файл json</param>
        public static void Beginning(string path, string psth)// начало работы программы 
        {
            Console.WriteLine("Напишите 1 чтобы создать департамент, напишите 2 чтобы удалить департамент, напишите 3 чтобы добавить департамент");
            char choice = 'д';//переменная для бесконечного цикла
            do
            {
                switch (Console.ReadLine())// выбор того что тебе нужно
                {
                    case "1":
                        AddendumXML(path , psth);// добавление компании
                        break;
                    case "2":
                        DeleteChoice(path, psth);// выбор удаление в Xml, Json
                        break;
                    case "3":
                        addroc(path, psth);// добавление уже имеющейся компании 
                        break;
                    default:
                        Console.WriteLine("пока");
                        break;


                }
                Console.WriteLine("если закончили напишите н если нет то д");
                choice = Console.ReadKey(true).KeyChar;// условие по закрытию  цикла
            }
            while (char.ToLower(choice) == 'д');
        }
        public static void AddendumXML(string path, string psth)// добавление сотрудника и департамента 
        {
            List<Department> departments = new List<Department>();//создание листа с департаментами
            List<Worker> workers = new List<Worker>();// создания листа с работниками
            List<Сompany> сompany = new List<Сompany>();

            Random random = new Random(); // рандомайзер
            Console.WriteLine("Введите названия департамента");
            string DepartmentName = Console.ReadLine();// название департамента
            Console.WriteLine("Напишите количество работников");
            int Quantity = Convert.ToInt32(Console.ReadLine());// количество сотрудников

            departments.Add(new Department()// создания департамента
            {
                DepartmentName = DepartmentName,
                Date = DateTime.Now,
                Quantity = Quantity
            });
            for (int i = 1; i <= Quantity; i++)//создания цикла работников
            {
                workers.Add(new Worker()//создания работника
                {
                    Name = $"name_{i}",
                    Surname = $"Фамилия_{i}",
                    Age = random.Next(18, 45),
                    DepartmentWorks = DepartmentName,
                    Salary = random.Next(18000, 200000),
                    Id = i

                });
            }
            сompany.Add(new Сompany()
            {
                Departments = departments,
                Workers = workers
            });// создание компании
            Console.WriteLine("варианты записи департаментов: в Xml варианте - 1, в Json варианте - 2  ");// вывод на консоль с выбором
            switch (Console.ReadLine())// условие по создания файла Xml или Json
            {
                case "1":
                   WorkingFiles.SerializeXml(сompany, path);//метод по сериализация в Xml
                    break;
                case "2":
                   WorkingFiles.serializeJson(psth, сompany);//метод по сериализации в Json
                    break;
                default:
                    Console.WriteLine("пока");
                    break;
            }
        }

        public static void addroc(string path, string psth)// добавление сотрудника и департамента, в уже имеющийся департамент
        {
            List<Сompany> company = choice(path, psth);// метод по выбору файла 

            List<Department> departments = new List<Department>();//создание листа с департаментами
            List<Worker> workers = new List<Worker>();// создания листа с работниками
            Random random = new Random(); // рандомайзер
            Console.WriteLine("Введите названия департамента");
            string DepartmentName = Console.ReadLine();// название департамента
            Console.WriteLine("Напишите количество работников");
            int Quantity = Convert.ToInt32(Console.ReadLine());// количество сотрудников

            departments.Add(new Department()// создания департамента
            {
                DepartmentName = DepartmentName,
                Date = DateTime.Now,
                Quantity = Quantity
            });
            for (int i = 1; i <= Quantity; i++)//создания цикла работников
            {
                workers.Add(new Worker()//создания работника
                {
                    Name = $"name_{i}",
                    Surname = $"Фамилия_{i}",
                    Age = random.Next(18, 45),
                    DepartmentWorks = DepartmentName,
                    Salary = random.Next(18000, 200000),
                    Id = i

                });
            }
            company.Add(new Сompany()
            {
                Departments = departments,
                Workers = workers
            });// создание компании
            Console.WriteLine("варианты записи департаментов: в Xml варианте - 1, в Json варианте - 2  ");// вывод на консоль с выбором
            switch (Console.ReadLine())
            {
                case "1":
                   WorkingFiles.SerializeXml(company, path);//метод по сериализация в Xml
                    break;
                case "2":
                   WorkingFiles.serializeJson(path, company);//метод по сериализации в Json
                    break;
                default:
                    Console.WriteLine("пока");
                    break;
            }// условие по создания файла Xml или Json
        }
        /// <summary>
        ///  В choice происходит выбор откуда брать информацию о департамента 
        /// </summary>
        /// <param name="path">файл  xml</param>
        /// <param name="psth">файл json</param>
        /// <returns></returns>
        public static List<Сompany> choice(string path, string psth)// выбор откуда нужно брать информацию о компании
        {
            // с файла xml или c файла  json
            Console.WriteLine("напишите что нужно серелизовать. 1 из xml, а 2 Json");
            switch (Console.ReadLine())//цикл для выбора
            {
                case "1":
                    List<Сompany> companies =WorkingFiles.DeserializeXml(path);// метод для  xml
                    return companies;
                case "2":
                    List<Сompany> company = WorkingFiles.DeserializeJson(psth);// метод для  json
                    return company;
                default:
                    return null;
            }

        }

        /// <summary>
        /// B DeleteChoice происходит выбор откуда удалять департамент с xml файла или с Json файла 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="psth"></param>
        public static void DeleteChoice(string path, string psth)// удаление департамента из файлов
        {
            Console.WriteLine("1 для удаление департамента в xml файле, 2 для удаление департамента в Json файле");
            switch (Console.ReadLine())//цикл для выбора
            {
                case "1":
                    Сompany.DeleteWorkerDepartamentXml(path);
                    break;
                case "2":
                    Сompany.DeleteworkerDepartamentJson(psth);
                    break;
                default:
                    Console.WriteLine("Вы ввели не правильное числа");
                    break;
            }
        }

    }
}
