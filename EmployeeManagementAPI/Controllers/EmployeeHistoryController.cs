using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{   
    [ApiController]
    [Route("api/employeesHistory")]
    public class EmployeeHistoryController : ControllerBase
    {
        private IEmployeeHistoryRepository _employeeHistoryRepository;
        private readonly IMapper _mapper;

        public EmployeeHistoryController(IEmployeeHistoryRepository employeeHistoryRepository, IMapper mapper)
        {
            _employeeHistoryRepository = employeeHistoryRepository ?? throw new ArgumentNullException(nameof(employeeHistoryRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesHistory()
        {   
            try
            {   
                var employeeHistoryEntities = await _employeeHistoryRepository.GetEmployeesHistory();
                // Returns status code 200 OK along with the list of employeesHistory (Models.EmployeeHistoryDto) in body of response
                return Ok(_mapper.Map<IEnumerable<Models.EmployeeHistoryDto>>(employeeHistoryEntities));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeHistory(int id)
        {
            try
            {
                var employeeHistoryEntity = await _employeeHistoryRepository.GetEmployeeHistory(id);

                if (employeeHistoryEntity == null)
                    return NotFound();

                return Ok(_mapper.Map<Models.EmployeeHistoryDto>(employeeHistoryEntity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateEmployeeHistory([FromBody] EmployeeHistoryForCreationDto employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                
                var createdEmployee = _mapper.Map<Entities.EmployeeHistory>(employee); 
                await _employeeHistoryRepository.CreateEmployeeHistory(createdEmployee);
                var createdEmployeeToReturn = _mapper.Map<Models.EmployeeHistoryDto>(createdEmployee);

                return CreatedAtAction(nameof(GetEmployeeHistory),
                    new { id = createdEmployeeToReturn.Id }, createdEmployeeToReturn);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeHistory(int id)
        {   
            try
            {
                var employeeEntity = await _employeeHistoryRepository.GetEmployeeHistory(id); 

                if (employeeEntity == null)
                    return NotFound($"EmployeeHistory with Id = {id} not found");

                await _employeeHistoryRepository.DeleteEmployeeHistory(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}