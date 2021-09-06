using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Worker
    {
        public string Name { get; set; }// имя

        public string Surname { get; set; }// фамилия

        public int Age { get; set; }// возраст

        public int Id { get; set; } //айди

        public int Salary { get; set; } // зарплата

        public string DepartmentWorks { get; set; } //департамент в котором работает

        public void works(string name, string surname, int age, int id, int salary, string departmentWorks) =>
            (Name, Surname, Age, Id, Salary, DepartmentWorks) = (name, surname, age, id, salary, departmentWorks);
        // вывод на экран 
        public new string ToString => $"{Id}{Name}{Surname}{Age}{Salary}{DepartmentWorks}";
       
    }
}
