using AutoMapper;
using Employee_Api.Data;
using Employee_Api.Dtos;
using Employee_Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Adapters;

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


        //POST api/employee
        [HttpPost]
        public ActionResult <EmployeeCreateDto> CreateEmployee(EmployeeCreateDto createDto)
        {
            var employeeModel = _mapper.Map<Employee>(createDto);

            _employeeRepo.CreateEmployee(employeeModel);

            _employeeRepo.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employeeModel);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id}, employeeReadDto);
        }


        //PUT api/employee/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmployeeUpdateDto employeeUpdateDto)
        {
            var employe = _employeeRepo.GetEmployeeById(id);

            if(employe == null)
            {
                return NotFound();
            }

            _mapper.Map(employeeUpdateDto, employe);

            _employeeRepo.UpdateEmployee(employe);
            _employeeRepo.SaveChanges();

            var employeeReadDto = _mapper.Map<EmployeeReadDto>(employe);

            return CreatedAtRoute(nameof(GetEmployeeById), new { Id = employeeReadDto.Id }, employeeReadDto);
        }

        //PATCH api/employee
           [HttpPatch("{id}")]
           public ActionResult PartialEmployeeUpdate(int id, JsonPatchDocument<EmployeeUpdateDto> patchDoc)
        {
            var employeeFromModel = _employeeRepo.GetEmployeeById(id);

            if(employeeFromModel == null)
            {
                return NotFound();
            }

            var employeeToPatch = _mapper.Map<EmployeeUpdateDto>(employeeFromModel);
            patchDoc.ApplyTo(employeeToPatch, (IObjectAdapter)ModelState);

            if (!TryValidateModel(employeeToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(employeeFromModel, employeeToPatch);
            _employeeRepo.SaveChanges();
            return NoContent();
        }



    }
}
