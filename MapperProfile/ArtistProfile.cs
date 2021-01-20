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
            CreateMap<ArtistUpdateDto, Artist>()
                .ForMember(x => x.Code, opt => opt.MapFrom(x => x.NewCode))
                .ForMember(x => x.FirstName, opt => opt.MapFrom(x => x.NewFirstName))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.NewLastName))
                .ForMember(x => x.Birthdate, opt => opt.MapFrom(x => x.NewBirthdate));
            CreateMap<ArtistSaveDto, Artist>();
            CreateMap<Artist, ArtistWithoutArtworkReadDto>();
            CreateMap<Artist, ArtistWithArtworkReadDto>()
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
