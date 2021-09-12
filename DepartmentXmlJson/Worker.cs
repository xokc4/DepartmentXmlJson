using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Worker
    {
        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// айди
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// зарплата
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// департамент в котором работает
        /// </summary>
        public string DepartmentWorks { get; set; } 
        /// <summary>
        /// конструктор работника
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="surname">фамилия</param>
        /// <param name="age">возраст</param>
        /// <param name="id">айди</param>
        /// <param name="salary">зарплата</param>
        /// <param name="departmentWorks">имя департамента</param>
        public void works(string name, string surname, int age, int id, int salary, string departmentWorks) =>
            (Name, Surname, Age, Id, Salary, DepartmentWorks) = (name, surname, age, id, salary, departmentWorks);
        /// <summary>
        /// вывод ниформации ToString
        /// </summary>
        public new string ToString => $"{Id}{Name}{Surname}{Age}{Salary}{DepartmentWorks}";
       
    }
}
