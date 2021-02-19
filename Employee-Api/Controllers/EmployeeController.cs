using AutoMapper;
using Employee_Api.Data;
using Employee_Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeRepo Repo, IMapper mapper)
        {
            _employeeRepo = Repo;
            _mapper = mapper;
        }


        //GET api/employee
        [HttpGet]
        public ActionResult <IEnumerable<EmployeeReadDto>> GetAllEmployee()
        {
            var employees = _employeeRepo.GetAllEmployee();
            return Ok(employees);
        }

        //GET api/employee/{id}
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult <EmployeeReadDto> GetEmployeeById(int id)
        {
            var employee = _employeeRepo.GetEmployeeById(id);
            if(employee != null)
            {
                return Ok(_mapper.Map<EmployeeReadDto>(employee));
            }
            return NotFound();
        }


    }
}
