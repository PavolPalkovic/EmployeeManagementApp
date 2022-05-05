using System;
using System.Collections.Generic;
using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetEmployees()
        {
            try
            {   
                var employeeEntities = await _employeeRepository.GetEmployees();
                // Returns status code 200 OK along with the list of employees (Models.EmployeeDto) in body of response
                return Ok(_mapper.Map<IEnumerable<Models.EmployeeDto>>(employeeEntities));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employeeEntity = await _employeeRepository.GetEmployee(id);

                if (employeeEntity == null)
                    return NotFound();

                return Ok(_mapper.Map<Models.EmployeeDto>(employeeEntity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeForCreationUpdateDto employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                
                var createdEmployee = _mapper.Map<Entities.Employee>(employee); 
                await _employeeRepository.CreateEmployee(createdEmployee);
                var createdEmployeeToReturn = _mapper.Map<Models.EmployeeDto>(createdEmployee);

                return CreatedAtAction(nameof(GetEmployee),
                    new { id = createdEmployeeToReturn.Id }, createdEmployeeToReturn);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {   
            try
            {
                var employeeEntity = await _employeeRepository.GetEmployee(id); 

                if (employeeEntity == null)
                    return NotFound($"Employee with Id = {id} not found");

                await _employeeRepository.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        // [FromBody] - Specifies that the value should be read from the body of the request
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeForCreationUpdateDto employee)
        {
            try
            {   
                var employeeEntity = await _employeeRepository.GetEmployee(id);

                if (employeeEntity == null)
                    return NotFound($"Employee with Id = {id} not found");

                _mapper.Map(employee, employeeEntity);
                await _employeeRepository.UpdateEmployee();
                
                return Ok(_mapper.Map<Models.EmployeeDto>(employeeEntity));
            }
            catch (Exception)
            {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating data");
            }
        }
    }
}