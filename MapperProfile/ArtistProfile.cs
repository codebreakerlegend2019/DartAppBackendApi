using Profile = AutoMapper.Profile;
using DartAppSingapore.Dtos.ArtistDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DartAppSingapore.Models;
using DartAppSingapore.Dtos.ArtworkDtos;

namespace DartAppSingapore.MapperProfile
{
    public class ArtistProfile:Profile
    {
        public ArtistProfile()
        {
            CreateMap<ArtistSaveDto, Artist>();
            CreateMap<Artist, ArtistSaveDto>();
            CreateMap<Artist, ArtistReadDto>()
             .AfterMap((src, dest) => 
             {
                 dest.Artworks = new List<ArtworkWithoutArtistReadDto>();
                 foreach(var artistArtwork in src.ArtistArtworks)
                 {
                     var artWork = artistArtwork.Artwork;
                     dest.Artworks.Add(new ArtworkWithoutArtistReadDto()
                     {
                         Id = artWork.Id,
                         Title = artWork.Title,
                         Notes = artWork.Notes
                     });
                 }
             });
        }
    }
}
