using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
   public class Department
    {
        /// <summary>
        /// названия департамента
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// дата создания
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// количество сотрудников
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// конструктор департамента 
        /// </summary>
        /// <param name="departmentName">имя департамента</param>
        /// <param name="date"> дата создания </param>
        /// <param name="quantity">количество работников</param>
        public void departament(string departmentName, DateTime date, int quantity) => 
            (DepartmentName, Date, Quantity) = (departmentName, date, quantity);

        /// <summary>
        /// вывод информации ToString
        /// </summary>
        public new string ToString => $"Имя: {DepartmentName} дата: {Date} количество людей: {Quantity}";

        
    }
}
