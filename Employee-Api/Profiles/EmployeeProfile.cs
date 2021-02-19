using AutoMapper;
using Employee_Api.Dtos;
using Employee_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeReadDto>();
            CreateMap<EmployeeCreateDto, Employee>();
        }
    }
}
