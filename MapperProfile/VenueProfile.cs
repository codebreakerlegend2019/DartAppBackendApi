using DartAppSingapore.Dtos.VenueDtos;
using DartAppSingapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace DartAppSingapore.MapperProfile
{
    public class VenueProfile:Profile
    {
        public VenueProfile()
        {
            CreateMap<Venue, VenueWithoutLocationReadDto>();
            CreateMap<Venue, VenueWithLocationReadDto>();
            CreateMap<VenueSaveDto, Venue>();
            CreateMap<VenueUpdateDto, Venue>()
                .ForMember(x => x.LocationId, opt => opt.MapFrom(x => x.NewLocationId))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.NewName));
        }
    }
}
