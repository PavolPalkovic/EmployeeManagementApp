using System;
using System.Collections.Generic;
using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
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
        public IActionResult GetEmployeesHistory()
        {
            var employeeHistoryEntities = _employeeHistoryRepository.GetEmployeesHistory();

            return Ok(_mapper.Map<IEnumerable<EmployeeHistoryDto>>(employeeHistoryEntities));
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeHistory(int id)
        {
            var employee = _employeeHistoryRepository.GetEmployeeHistory(id);

            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeHistoryDto>(employee));
        }
        
        [HttpPost]
        public IActionResult CreateEmployeeHistory([FromBody] EmployeeHistoryForCreationDto employee)
        {
            var finalEmployee = _mapper.Map<Entities.EmployeeHistory>(employee);

            _employeeHistoryRepository.CreateEmployeeHistory(finalEmployee);
            _employeeHistoryRepository.Save();

            var employeeHistoryEntities = _employeeHistoryRepository.GetEmployeesHistory();
            return Ok(_mapper.Map<IEnumerable<EmployeeHistoryDto>>(employeeHistoryEntities));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeHistory(int id)
        {   
            var employeeEntity = _employeeHistoryRepository.GetEmployeeHistory(id);
            _employeeHistoryRepository.DeleteEmployeeHistory(employeeEntity);
            _employeeHistoryRepository.Save();

            var employeeHistoryEntities = _employeeHistoryRepository.GetEmployeesHistory();
            return Ok(_mapper.Map<IEnumerable<EmployeeHistoryDto>>(employeeHistoryEntities));
        }
    }
}