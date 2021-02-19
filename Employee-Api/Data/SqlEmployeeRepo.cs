using Employee_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Data
{
    public class SqlEmployeeRepo : IEmployeeRepo    
    {
        private readonly EmployeeContext _context;
        public SqlEmployeeRepo(EmployeeContext employeeContext)
    {
            _context = employeeContext;
    }
        public void CreateEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.employees.FirstOrDefault(s => s.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
