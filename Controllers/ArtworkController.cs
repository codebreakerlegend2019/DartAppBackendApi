using AutoMapper;
using DartAppSingapore.Dtos.ArtworkDtos;
using DartAppSingapore.Helpers;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using DartAppSingapore.Persistence.ArtworkRepositories;
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
    public class ArtworkController : ControllerBase
    {
        #region Fields
        private readonly ICrud<Artwork> _iCrudArtwork;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IArtworkRepo _artworkRepo;
        #endregion

        #region Constructor
        public ArtworkController(ICrud<Artwork> iCrudArtwork, IUnitOfWork unitOfWork,
            IMapper mapper, IArtworkRepo artworkRepo)
        {
            this._iCrudArtwork = iCrudArtwork;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._artworkRepo = artworkRepo;
        }
        #endregion

        #region Endpoints
        /// <summary>
        /// Create Artworks with Artists (Required to create Artists first!) 
        /// </summary>
        /// <param name="artworkDto"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> Add([FromBody] ArtworkSaveDto artworkDto)
        {
            var artWork = _mapper.Map<Artwork>(artworkDto);
            _iCrudArtwork.Create(artWork);
            await _artworkRepo.AddArtists(artworkDto.ArtistIds, artWork.Id);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been Saved!"));
            return StatusCode(201);
        }
        /// <summary>
        /// Get All Artworks with or without Artists
        /// </summary>
        /// <param name="isArtistsIncluded"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] bool isArtistsIncluded)
        {
            var artworks = await _iCrudArtwork.GetAll(isArtistsIncluded);
            if (artworks == null)
                return NoContent();
            return (isArtistsIncluded) ? Ok(_mapper.Map<List<ArtworkWithArtistReadDto>>(artworks)) :
                Ok(_mapper.Map<List<ArtworkWithoutArtistReadDto>>(artworks));
        }
        /// <summary>
        /// Get Artworks by id with or without Artists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isArtistsIncluded"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBydId([FromRoute] int id,[FromQuery] bool isArtistsIncluded)
        {
            var artwork = await _iCrudArtwork.Get(id,isArtistsIncluded);
            if (artwork == null)
                return NotFound();
            return (isArtistsIncluded) ? Ok(_mapper.Map<ArtworkWithArtistReadDto>(artwork)) :
                Ok(_mapper.Map<ArtworkWithoutArtistReadDto>(artwork));
        }
        /// <summary>
        /// Update Artwork Informations 
        /// </summary>
        /// <param name="artworkUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] ArtworkUpdateDto artworkUpdateDto)
        {
            var artwork = await _iCrudArtwork.Get(artworkUpdateDto.ArtworkIdToUpdate,true);
            if (artwork == null)
                return NotFound();
            _iCrudArtwork.Update(artworkUpdateDto, artwork);
            _artworkRepo.DeleteArtistArtworkPairs(artwork.ArtistArtworks);
            await _artworkRepo.AddArtists(artworkUpdateDto.NewArtistIds, artworkUpdateDto.ArtworkIdToUpdate);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been Saved!"));
            return Ok(_mapper.Map<ArtworkWithArtistReadDto>(artwork));
        }
        /// <summary>
        /// Delete Artworks.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var artwork = await _iCrudArtwork.Get(id,true);
            if (artwork == null)
                return NotFound();
            if (artwork.ArtistArtworks.Any())
                _artworkRepo.DeleteArtistArtworkPairs(artwork.ArtistArtworks);
            _iCrudArtwork.Delete(artwork);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest(ErrorHelper.PutError("Nothing has been Saved!"));
            return Ok(_mapper.Map<ArtworkWithoutArtistReadDto>(artwork));
        }
        #endregion
    }
}
