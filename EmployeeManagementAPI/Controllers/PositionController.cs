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
    [Route("api/positions")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public PositionController(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository ?? throw new ArgumentNullException(nameof(positionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<IActionResult> GetPositions()
        {   
            try
            {   
                var positionEntities = await _positionRepository.GetPositions();
                // Returns status code 200 OK along with the list of positions (Models.PositionDto) in body of response
                return Ok(_mapper.Map<IEnumerable<Models.PositionDto>>(positionEntities));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPosition(int id)
        {   
            try
            {
                var positionEntity = await _positionRepository.GetPosition(id);

                if (positionEntity == null)
                    return NotFound($"Position with Id = {id} not found");

                return Ok(_mapper.Map<Models.PositionDto>(positionEntity));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        // [FromBody] - PositionForCreationDto argument is deserialized from the request body
        public async Task<IActionResult> CreatePosition([FromBody] PositionForCreationDto position)
        {   
            try
            {
                // Mapping from PositionForCreationDto to Entities.Position
                var createdPosition = _mapper.Map<Entities.Position>(position); 
                await _positionRepository.CreatePosition(createdPosition);
                var createdPositionToReturn = _mapper.Map<Models.PositionDto>(createdPosition);

                return CreatedAtAction(nameof(GetPosition),
                    new { id = createdPositionToReturn.Id }, createdPositionToReturn);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new position record");
            }
        }   

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePosition(int id)
        {   
            try
            {
                var postionEntity = await _positionRepository.GetPosition(id); 

                if (postionEntity == null)
                    return NotFound($"Position with Id = {id} not found");

                await _positionRepository.DeletePosition(id);
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