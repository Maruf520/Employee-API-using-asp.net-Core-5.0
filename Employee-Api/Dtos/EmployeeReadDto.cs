using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Dtos
{
    public class EmployeeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OfficeName { get; set; }
        public string Position { get; set; }
    }
}
