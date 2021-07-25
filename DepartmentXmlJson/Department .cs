using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Department
    {
        public string DepartmentName;// названия департамента

        public DateTime Date;// дата создания

        public uint quantity;// количество сотрудников

        public void Departament(string DepartmentName, DateTime Date, uint quantity)// метод по выводу департамента
        {
            this.DepartmentName = DepartmentName;
            this.Date = Date;
            this.quantity = quantity;
        }

        public string Print()// вывод инвормациии
        {
            return $"Имя: {DepartmentName} дата: {Date} количество людей: {quantity}";
        }
    }
}
