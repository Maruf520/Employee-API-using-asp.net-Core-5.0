using Employee_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Data
{
    interface IEmployeeRepo
    {
        bool SaveChanges();
        IEnumerable<Employee> GetAllEmployee(Employee employee);
        Employee GetEmployeeById(int id);
        void CreateEmployee(Employee employee);

    }
}
