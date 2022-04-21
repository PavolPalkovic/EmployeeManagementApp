using System;
using System.Collections.Generic;
using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employeeEntities = _employeeRepository.GetEmployees();

            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
            // Manually Mapping Entities to DTOs
            // var results = new List<EmployeeDto>();
           
            // foreach (var employeeEntity in employeeEntities)
            // {
            //     results.Add(new EmployeeDto
            //     {
            //         Id = employeeEntity.Id,
            //         FirstName = employeeEntity.FirstName,
            //         LastName = employeeEntity.LastName
            //     });
            // }
            // return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(employee));
            // var employeeResult = new EmployeeDto() 
            // {
            //     Id = employee.Id,
            //     FirstName = employee.FirstName,
            //     LastName = employee.LastName
            // };
            // return Ok(employee);
        }
        
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationUpdateDto employee)
        {
            var finalEmployee = _mapper.Map<Entities.Employee>(employee);

            _employeeRepository.CreateEmployee(finalEmployee);
            _employeeRepository.Save();

            var employeeEntities = _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {   
            var employeeEntity = _employeeRepository.GetEmployee(id);
            _employeeRepository.DeleteEmployee(employeeEntity);
            _employeeRepository.Save();

            var employeeEntities = _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }

        // [FromBody] - Specifies that the value should be read from the body of the request
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeForCreationUpdateDto employee)
        {
            var employeeEntity = _employeeRepository.GetEmployee(id);

            _mapper.Map(employee, employeeEntity);
            _employeeRepository.Save();

            var employeeEntities = _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }


        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateEmployee(int id, [FromBody] JsonPatchDocument<EmployeeForCreationUpdateDto> patchDoc)
        {   
            var employeeEntity = _employeeRepository.GetEmployee(id);
            var employeeToPatch = _mapper.Map<EmployeeForCreationUpdateDto>(employeeEntity);

            patchDoc.ApplyTo(employeeToPatch);

            _mapper.Map(employeeToPatch, employeeEntity);

            _employeeRepository.UpdateEmployee(employeeEntity);
            _employeeRepository.Save();


            var employeeEntities = _employeeRepository.GetEmployees();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities));
        }


    }
}