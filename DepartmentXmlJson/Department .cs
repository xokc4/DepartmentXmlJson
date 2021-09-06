using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Department
    {
        public string DepartmentName { get; set; }// названия департамента

        public DateTime Date { get; set; }// дата создания

        public int Quantity { get; set; }// количество сотрудников

        public void departament(string departmentName, DateTime date, int quantity) => 
            (DepartmentName, Date, Quantity) = (departmentName, date, quantity);

        // вывод инвормациии
        public new string ToString => $"Имя: {DepartmentName} дата: {Date} количество людей: {Quantity}";

        
    }
}
