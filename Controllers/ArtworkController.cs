using AutoMapper;
using DartAppSingapore.Dtos.ArtworkDtos;
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
        public ArtworkController(ICrud<Artwork> iCrudArtwork,IUnitOfWork unitOfWork,
            IMapper mapper, IArtworkRepo artworkRepo)
        {
            this._iCrudArtwork = iCrudArtwork;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._artworkRepo = artworkRepo;
        }
        #endregion

        #region Endpoints
        [HttpPost]
        public async Task<IActionResult> Add ([FromBody] ArtworkSaveDto artworkDto)
        {
            var artWork = _mapper.Map<Artwork>(artworkDto);
            _iCrudArtwork.Create(artWork);
            if (!await _unitOfWork.SuccessSaveChangesAsync())
                return BadRequest("Nothing has been Saved");
            if (!await _artworkRepo.AddArtists(artworkDto.ArtistIds, artWork.Id)) 
                return BadRequest("No ArtistArtwork Saved");
            return StatusCode(201);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artworks = await _iCrudArtwork.GetAll();
            if (artworks == null)
                return NoContent();
            return Ok(_mapper.Map<List<ArtworkReadDto>>(artworks));
        }
        #endregion
    }
}
