using AutoMapper;
using DartAppSingapore.Dtos.ArtistDtos;
using DartAppSingapore.Helpers;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using DartAppSingapore.Persistence.ArtistRepositories;
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
        private readonly IArtistRepo _artistRepo;
        #endregion

        #region Constructor
        public ArtistController(ICrud<Artist> iCrudArtist, IMapper mapper,
            IUnitOfWork unitOfWork,IArtistRepo artistRepo)
        {
            this._iCrudArtist = iCrudArtist;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            _artistRepo = artistRepo;
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Create Artists To Database
        /// </summary>
        /// <param name="artistDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ArtistSaveDto artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);
            _iCrudArtist.Create(artist);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return StatusCode(201);
        }/// <summary>
        /// Get All Artist with or without artworks
        /// </summary>
        /// <param name="isArtworksIncluded"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool isArtworksIncluded)
        {
            var artists = await _iCrudArtist.GetAll(isArtworksIncluded);
            if (artists == null)
                return NoContent();
            return (isArtworksIncluded) ? Ok(_mapper.Map<List<ArtistWithArtworkReadDto>>(artists))
                : Ok(_mapper.Map<List<ArtistWithoutArtworkReadDto>>(artists));
        }
        /// <summary>
        /// Get Artist by id with or without artworks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isArtworksIncluded"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] bool isArtworksIncluded)
        {
            var artist = await _iCrudArtist.Get(id,isArtworksIncluded);
            if (artist == null)
                return NotFound();
            return (isArtworksIncluded) ? Ok(_mapper.Map<ArtistWithArtworkReadDto>(artist))
                : Ok(_mapper.Map<ArtistWithoutArtworkReadDto>(artist));
        }
        /// <summary>
        /// Update Artist informations
        /// </summary>
        /// <param name="artistUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ArtistUpdateDto artistUpdateDto)
        {
            var artist = await _iCrudArtist.Get(artistUpdateDto.ArtistIdToUpdate);
            if (artist == null)
                return NotFound();
            _iCrudArtist.Update(artistUpdateDto, artist);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been saved!"));
            return Ok(artist);
        }
        /// <summary>
        /// Delete Artist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var artist = await _iCrudArtist.Get(id,true);
            if (artist == null)
                return NotFound();
            if(artist.ArtistArtworks.Any())
                 _artistRepo.DeleteArtistArtoworkPairs(artist.ArtistArtworks);
            _iCrudArtist.Delete(artist);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been deleted!"));
            return Ok(_mapper.Map<ArtistWithoutArtworkReadDto>(artist));
        }
        #endregion
    }
}
