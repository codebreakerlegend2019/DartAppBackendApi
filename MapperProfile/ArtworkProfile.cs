using DartAppSingapore.Dtos.ArtistDtos;
using DartAppSingapore.Dtos.ArtworkDtos;
using DartAppSingapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;
namespace DartAppSingapore.MapperProfile
{
    public class ArtworkProfile:Profile
    {
        public ArtworkProfile()
        {
            CreateMap<Artwork, ArtworkSaveDto>();
            CreateMap<ArtworkUpdateDto, Artwork>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.NewTitle))
                .ForMember(x => x.Notes, opt => opt.MapFrom(x => x.NewNotes));
            CreateMap<Artwork, ArtworkWithArtistReadDto>()
             .AfterMap((src, dest) =>
             {
                 dest.Artists = new List<ArtistWithoutArtworkReadDto>();
                 foreach (var artistArtwork in src.ArtistArtworks)
                 {
                     var artist = artistArtwork.Artist;
                     dest.Artists.Add(new ArtistWithoutArtworkReadDto()
                     {
                         Id = artist.Id,
                         Code = artist.Code,
                         FirstName = artist.FirstName,
                         LastName = artist.LastName,
                         Birthdate = artist.Birthdate
                     });
                 }
             });
            CreateMap<Artwork, ArtworkWithoutArtistReadDto>();
        }
    }
}
