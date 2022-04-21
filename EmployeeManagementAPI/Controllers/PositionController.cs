using System;
using System.Collections.Generic;
using AutoMapper;
using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
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
        public IActionResult GetPositions()
        {   
            var positionEntities = _positionRepository.GetPositions();
            
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(positionEntities));
        }

        [HttpPost]
        // [FromBody] - PositionForCreationDto argument is deserialized from the request body
        public IActionResult CreatePosition([FromBody] PositionForCreationDto position)
        {   
            // Mapping from PositionForCreationDto to Entities.Position
            var finalPosition = _mapper.Map<Entities.Position>(position);

            _positionRepository.AddPosition(finalPosition);
            _positionRepository.Save();

            var positionEntities = _positionRepository.GetPositions();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(positionEntities));
        }   

        [HttpDelete("{id}")]
        public IActionResult DeletePosition(int id)
        {   
            var positionEntity = _positionRepository.GetPosition(id);

            _positionRepository.DeletePosition(positionEntity);

            _positionRepository.Save();

            var positionEntities = _positionRepository.GetPositions();
            return Ok(_mapper.Map<IEnumerable<PositionDto>>(positionEntities));
        }
    }
}