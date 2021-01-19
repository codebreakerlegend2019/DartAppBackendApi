using AutoMapper;
using DartAppSingapore.Dtos.ZoneDtos;
using DartAppSingapore.Helpers;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using DartAppSingapore.Persistence.UnitOfWorkRepositories;
using DartAppSingapore.Validators;
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
    public class ZoneController : ControllerBase
    {
        #region Fields
        private readonly ICrud<Zone> _iCrudZone;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Constructor
        public ZoneController(ICrud<Zone> iCrudZone, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _iCrudZone = iCrudZone;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Endpoints
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ZoneSaveDto zoneSaveDto)
        {
            var zone = _mapper.Map<Zone>(zoneSaveDto);
            _iCrudZone.Create(zone);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved"));
            return StatusCode(201);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var zones = await _iCrudZone.GetAll();
            if (zones == null)
                return NoContent();
            return Ok(_mapper.Map<List<ZoneReadDto>>(zones));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var zone = await _iCrudZone.Get(id);
            if (zone == null)
                return NotFound();
            return Ok(_mapper.Map<ZoneReadDto>(zone));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ZoneUpdateDto zoneUpdateDto)
        {
            var zone = await _iCrudZone.Get(zoneUpdateDto.ZoneIdToUpdate);
            if (zone == null)
                return NotFound();
            _iCrudZone.Update(zoneUpdateDto, zone);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved"));
            return Ok(zone);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var zone = await _iCrudZone.Get(id);
            if (zone == null)
                return NotFound();
            _iCrudZone.Delete(zone);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been Deleted"));
            return Ok(zone);
        }
        #endregion

    }
}
