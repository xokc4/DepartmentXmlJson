using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
    public class Сompany
    {
       public List<Department> Departments { get; set; }

       public List<Worker> Workers { get; set; }


        public void Company (List<Worker> workers, List<Department> departments)
        {
            Departments = departments;
            Workers = workers;

        }
        public new string ToString => $"{Departments} {Workers} ";
    }
    
}
