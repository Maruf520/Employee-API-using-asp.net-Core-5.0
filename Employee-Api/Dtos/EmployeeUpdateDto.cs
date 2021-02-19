using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Dtos
{
    public class EmployeeUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string OfficeName { get; set; }
        [Required]
        public string Position { get; set; }
    }
}
