using AutoMapper;
using DartAppSingapore.Dtos.VenueDtos;
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
    public class VenueController : ControllerBase
    {
        #region Fields
        private readonly ICrud<Venue> _iCrudVenue;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public VenueController(ICrud<Venue> iCrudVenue, IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _iCrudVenue = iCrudVenue;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion
        /// <summary>
        /// </summary>
        /// <param name="venueSaveDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Create ([FromBody] VenueSaveDto venueSaveDto)
        {
            var venue = _mapper.Map<Venue>(venueSaveDto);
            _iCrudVenue.Create(venue);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return StatusCode(201);
        }
        /// <summary>
        /// </summary>
        /// <param name="isLocationIncluded"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool isLocationIncluded)
        {
            var venues = await _iCrudVenue.GetAll(isLocationIncluded);
            if (venues == null)
                return NoContent();
            return (isLocationIncluded) ? Ok(_mapper.Map<List<VenueWithLocationReadDto>>(venues))
                : Ok(_mapper.Map<List<VenueWithoutLocationReadDto>>(venues));
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isLocationIncluded"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll([FromRoute]int id,[FromQuery] bool isLocationIncluded)
        {
            var venue = await _iCrudVenue.Get(id,isLocationIncluded);
            if (venue == null)
                return NoContent();
            return (isLocationIncluded) ? Ok(_mapper.Map<VenueWithLocationReadDto>(venue))
                : Ok(_mapper.Map<VenueWithoutLocationReadDto>(venue));
        }
        /// <summary>
        /// </summary>
        /// <param name="venueUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] VenueUpdateDto venueUpdateDto)
        {
            var venue = await _iCrudVenue.Get(venueUpdateDto.VenueIdToUpdate);
            if (venue == null)
                return NotFound();
            _iCrudVenue.Update(venueUpdateDto, venue);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return Ok(venue);
        }
        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var venue = await _iCrudVenue.Get(id);
            if (venue == null)
                return NotFound();
            _iCrudVenue.Delete(venue);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been deleted!"));
            return Ok(venue);
        }
    }
}
