using AutoMapper;
using DartAppSingapore.Dtos.LocationDtos;
using DartAppSingapore.Helpers;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using DartAppSingapore.Persistence.UnitOfWorkRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        #region Fields
        private readonly ICrud<Location> _iCrudLocation;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public LocationController(ICrud<Location> iCrudLocation, 
            IMapper mapper, 
            IUnitOfWork unitOfWork)
        {
            _iCrudLocation = iCrudLocation;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion

        #region Endpoints
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] LocationSaveDto locationSaveDto)
        {
            var location = _mapper.Map<Location>(locationSaveDto);
            _iCrudLocation.Create(location);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool isZoneIncluded)
        {
            var locations = await _iCrudLocation.GetAll(isZoneIncluded);
            if (locations == null)
                return NoContent();
            return (isZoneIncluded) ? Ok(_mapper.Map<List<LocationWithZoneReadDto>>(locations)) :
                Ok(_mapper.Map<List<LocationWithoutZoneReadDto>>(locations));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute] int id, [FromQuery] bool isZoneIncluded)
        {
            var location = await _iCrudLocation.Get(id, isZoneIncluded);
            if (location == null)
                return NotFound();
            return (isZoneIncluded) ? Ok(_mapper.Map<LocationWithZoneReadDto>(location)) :
                Ok(_mapper.Map<LocationWithoutZoneReadDto>(location));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] LocationUpdateDto locationUpdateDto)
        {
            var location = await _iCrudLocation.Get(locationUpdateDto.LocationIdToUpdate);
            if (location == null)
                return NotFound();
            _iCrudLocation.Update(locationUpdateDto, location);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return Ok(location);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var location = await _iCrudLocation.Get(id);
            if (location == null)
                return NotFound();
            _iCrudLocation.Delete(location);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been deleted!"));
            return Ok(location);
        } 
        #endregion
    }
}
