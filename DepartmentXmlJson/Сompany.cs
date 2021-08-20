using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentXmlJson
{
    public class Сompany
    {
       public List<Department> departments;

       public List<Worker> workers;


        public void Company (List<Worker> workers, List<Department> departments)
        {
            this.departments = departments;
            this.workers = workers;

        }
        public string Print()
        {
            return $"{departments} {workers} ";
        }
    }
}
