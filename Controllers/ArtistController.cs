using AutoMapper;
using DartAppSingapore.Dtos.ArtistDtos;
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
    public class ArtistController : ControllerBase
    {
        #region Field
        private readonly ICrud<Artist> _iCrudArtist;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public ArtistController(ICrud<Artist> iCrudArtist,IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            this._iCrudArtist = iCrudArtist;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        #endregion

        #region Endpoints
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ArtistSaveDto artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);
            _iCrudArtist.Create(artist);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest("Nothing has been saved");
            return StatusCode(201);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _iCrudArtist.GetAll();
            if (artists == null)
                return NoContent();
            return Ok(_mapper.Map<List<ArtistReadDto>>(artists));
        }
        #endregion
    }
}
