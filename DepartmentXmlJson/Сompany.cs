using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DepartmentXmlJson
{
    public class Сompany
    {/// <summary>
     /// объект департаментов
     /// </summary>
        public List<Department> Departments { get; set; }
        /// <summary>
        /// объект работников
        /// </summary>
       public List<Worker> Workers { get; set; }

        /// <summary>
        /// создание конструктора 
        /// </summary>
        /// <param name="workers">объект с работниками</param>
        /// <param name="departments">объект с департаментами</param>
        public void Company (List<Worker> workers, List<Department> departments)
        {
            Departments = departments;
            Workers = workers;

        }
        /// <summary>
        /// вывод информации в ToString
        /// </summary>
        public new string ToString => $"{Departments} {Workers} ";

        /// <summary>
        /// в  DeleteworkerDepartamentJson удаление департамента в Json файле
        /// </summary>
        /// <param name="psth"></param>
        public static void DeleteworkerDepartamentJson(string psth)
        {
            List<Сompany> company = WorkingFiles.DeserializeJson(psth);
            Console.WriteLine("напишите имя департамента ");
            string NAme = Console.ReadLine();
            Сompany сompanyOne = null;

            bool flag = false;

            int index = -1;
            foreach (var item in company)
            {
                var s = item.Departments.Where(x => x.DepartmentName == NAme).Count();
                if (s != 0)
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

            if (flag == false)
            {
                Console.WriteLine("нет такого департамента");
            }
            company.RemoveAt(index);

            WorkingFiles.serializeJson(psth, company);
        }// удаление департамента Json
        /// <summary>
        /// в  DeleteWorkerDepartamentXml удаление департамента в Xml файле
        /// </summary>
        /// <param name="path"></param>
        public static void DeleteWorkerDepartamentXml(string path)// удаление департамента xml 
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            xRoot.RemoveAll();
            xDoc.Save(path);
        }


    }
    
}
