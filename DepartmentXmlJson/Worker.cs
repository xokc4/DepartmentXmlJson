using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Worker
    {
        public string Name;// имя

        public string Surname;// фамилия

        public int Age;// возраст

        public int Id; //айди

        public int Salary; // зарплата

        public string DepartmentWorks; //департамент в котором работает

        public void works(string Name, string Surname, int Age, int Id, int Salary, string DepartmentWorks)// метод по выводу работника
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Id = Id;
            this.Salary = Salary;
            this.DepartmentWorks = DepartmentWorks;
        }
        public string  Print()// вывод на экран 
            {
            return $"{this.Id}{this.Name}{this.Surname}{this.Age}{this.Salary}{this.DepartmentWorks}";
            }
    }
}
