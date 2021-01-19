using Profile = AutoMapper.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DartAppSingapore.Models;
using DartAppSingapore.Dtos.LocationDtos;

namespace DartAppSingapore.MapperProfile
{
    public class LocationProfile:Profile
    {
        public LocationProfile()
        {
            CreateMap<Location, LocationSaveDto>();
            CreateMap<LocationSaveDto, Location>();
            CreateMap<LocationUpdateDto, Location>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.NewName))
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.NewType))
                .ForMember(x => x.Latitude, opt => opt.MapFrom(x => x.NewLatitude))
                .ForMember(x => x.Longitude, opt => opt.MapFrom(x => x.NewLongitude))
                .ForMember(x => x.ZoneId, opt => opt.MapFrom(x => x.NewZoneId));
            CreateMap<Location, LocationWithZoneReadDto>();
            CreateMap<Location, LocationWithoutZoneReadDto>();

        }
    }
}
