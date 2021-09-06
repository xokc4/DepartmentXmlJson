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
        static void Main(string[] args)
        {
            string path = @"C:\Новая папка\serealize.xml";// путь к папке xml
            string psth = @"C:\Новая папка\serealize.Json";// путь к папке Json
            Beginning(path, psth);// начала работы метода

            Console.ReadKey();
        }
        public static void Beginning(string path, string psth)// начало работы программы 
        {
            Console.WriteLine("Напишите 1 чтобы создать департамент, напишите 2 чтобы удалить департамент, напишите 3 чтобы добавить департамент");
            char choice = 'д';//переменная для бесконечного цикла
            do
            {
                switch (Console.ReadLine())// выбор того что тебе нужно
                {
                    case "1":
                        AddendumXML(path);// добавление сомпании
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
        public static void AddendumXML(string path)// добавление сотрудника и департамента 
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
                    SerializeXml(сompany, path);//метод по сериализация в Xml
                    break;
                case "2":
                    serializeJson(path, сompany);//метод по сериализации в Json
                    break;
                default:
                    Console.WriteLine("пока");
                    break;
            }
        }
        public static void SerializeXml(List<Сompany> сompany, string path)// сериализация в Xml
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Сompany>));// создания  сериализация в Xml

            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);// создания потока

            xmlSerializer.Serialize(stream, сompany);// запуск сериализации

            stream.Close();// закрытие потока
        }
        public static void serializeJson(string path, List<Сompany> сompany)// сериализации в Json
        {
            string json = JsonConvert.SerializeObject(сompany);// создания сериализации
            File.WriteAllText(@"C:\Новая папка\serealize.Json", json);// запись

        }
        public static List<Сompany> DeserializeXml(string path)// десериализации Xml
        {

            List<Сompany> сompany = new List<Сompany>();

            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Сompany>));

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            сompany = xmlSerializer.Deserialize(stream) as List<Сompany>;//десериализация

            stream.Close();// закрытие потока

            return сompany;


        }
        public static List<Сompany> DeserializeJson(string psth)//десериализации Json
        {
            List<Сompany> сompanies = new List<Сompany>();
            string json = File.ReadAllText(psth);// открытие папки
            сompanies = JsonConvert.DeserializeObject<List<Сompany>>(json);//десериализация
            return сompanies;// вывод листа
        }
        public static void DeleteWorkerDepartamentXml(string path)// удаление департамента и сотрудника 
        {


            Console.WriteLine("если хотите удалить  департаменты ");

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNode firstNode = xRoot.FirstChild;
            Console.WriteLine("");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:

                    break;
                case 2:
                    xRoot.RemoveAll();
                    break;
                default:
                    Console.WriteLine("вы нажали другую кнопку");
                    break;
            }
            xDoc.Save(path);


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
                    SerializeXml(company, path);//метод по сериализация в Xml
                    break;
                case "2":
                    serializeJson(path, company);//метод по сериализации в Json
                    break;
                default:
                    Console.WriteLine("пока");
                    break;
            }// условие по создания файла Xml или Json
        }
        public static List<Сompany> choice(string path, string psth)// выбор откуда нужно брать информацию о компании
        {
            // с файла xml или c файла  json
            Console.WriteLine("напишите что нужно серелизовать. 1 из xml, а 2 Json");
            switch (Console.ReadLine())//цикл для выбора
            {
                case "1":
                    List<Сompany> companies = DeserializeXml(path);// метод для  xml
                    return companies;
                case "2":
                    List<Сompany> company = DeserializeJson(psth);// метод для  json
                    return company;
                default:
                    return null;
            }

        }
        public static void DeleteworkerDepartamentJson(string psth)
        {
            List<Сompany> company = DeserializeJson(psth);
           string  NAme =  Console.ReadLine();
            Сompany сompanyOne = null;
            
            bool flag = false;
            
            int index =-1;
            foreach (var item in company)
            {
                var s = item.Departments.Where(x => x.DepartmentName == NAme).Count();
                if(s !=0)
                {
                    сompanyOne = item;
                    flag = true;
                    index++;
                }
                else
                {
                    index++;
                }
                
            }
            
            if(flag == false)
            {
                Console.WriteLine("нет такого департамента");
            }
            company.RemoveAt(index);

            serializeJson(psth, company);
        }
        public static void DeleteChoice(string path, string psth)
        {
            Console.WriteLine("1 для удаление департамента в xml файле, 2 для удаление департамента в Json файле");
            switch (Console.ReadLine())//цикл для выбора
            {
                case "1":
                    DeleteWorkerDepartamentXml(path);
                    break;
                case "2":
                    DeleteworkerDepartamentJson(psth);
                    break;
                default:
                    Console.WriteLine("Вы ввели не правильное числа");
                    break;
            }
        }

    }
}
