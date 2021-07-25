using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;


namespace DepartmentXmlJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Новая папка\serealize.xml";// путь к папе
            Beginning(path);// начала работы метода
            Console.ReadKey();
        }
        public static void Beginning(string path)// начало работы программы
        {
            char choice = 'д';
            do
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        AddendumXML(path);
                        break;
                    case "2":
                        DeleteWorkerDepartament(path);
                        break;
                    case "3":

                        break;
                    default:
                        Console.WriteLine("пока");
                        break;


                }
                choice = Console.ReadKey(true).KeyChar;
            }
            while (char.ToLower(choice) == 'д');
        }
        public static void AddendumXML(string path)// добавление сотрудника и департамента 
        {
            List<Department> departments = new List<Department>();//создание листа с департаментами
            List<Worker> workers = new List<Worker>();// создания листа с работниками


            Random random = new Random(); // рандомайзер
            Console.WriteLine("Введите названия департамента");
            string DepartmentName = Console.ReadLine();
            Console.WriteLine("Напишите количество работников");
            uint Quantity = Convert.ToUInt32(Console.ReadLine());

            departments.Add(new Department()// создания департамента
            {
                DepartmentName = DepartmentName,
                Date = DateTime.Now,
                quantity = Quantity
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
            Console.WriteLine("варианты записи департаментов: в Xml варианте - 1, в Json варианте - 2  ");
            switch (Console.ReadLine())// условие по создания файла Xml или Json
            {
                case "1":
                    SerializeXml(departments, workers, path);
                    break;
                case "2":
                    serializeJson(path, departments);
                    break;
                default:
                    Console.WriteLine("пока");
                    break;
            }
        }
        public static void SerializeXml(List<Department> departments1, List<Worker> workers, string path)// сериализация в Xml
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));// создания  сериализация в Xml

            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);// создания потока

            xmlSerializer.Serialize(stream, departments1);// запуск сериализации

            stream.Close();// закрытие потока
        }
        public static void serializeJson(string path, List<Department> departments)// сериализации в Json
        {
            string json = JsonConvert.SerializeObject(departments);// создания сериализации
            File.WriteAllText(@"C:\Новая папка\serealize.Json", json);// запись

        }
        public List<Department> DeserializeXml(string path)// десериализации Xml
        {
            List<Department> departments = new List<Department>();
            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Department>));

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            departments = xmlSerializer.Deserialize(stream) as List<Department>;//десериализация

            stream.Close();// закрытие потока

            return departments;//вывод листа
        }
        public List<Department> DeserializeJson()
        {
            List<Department> departments = new List<Department>();
            string json = File.ReadAllText(@"C:\Новая папка\serealize.Json");// открытие папки
            departments = JsonConvert.DeserializeObject<List<Department>>(json);//десериализация
            return departments;// вывод листа
        }
        public static void DeleteWorkerDepartament(string path)// удаление департамента и сотрудника 
        {
            string xml = File.ReadAllText(path);// открытие файла
                               
            var col = XDocument.Parse(xml)//чтение файла
                               .Descendants("Department")
                               .ToList();

            Console.WriteLine("ведите имя департамента");
            string keyword = Console.ReadLine();// имя по которому будет находиться департамент


            foreach (var i in col)// чтение файла
            {
                Console.WriteLine(i.Element("DepartmentName"));// просмотр имени департамента 
            }
        }
    }

}
