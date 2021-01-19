using Profile = AutoMapper.Profile;
using DartAppSingapore.Dtos.ZoneDtos;
using DartAppSingapore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.MapperProfile
{
    public class ZoneProfile:Profile
    {
        public ZoneProfile()
        {
            CreateMap<ZoneSaveDto, Zone>();
            CreateMap<ZoneUpdateDto, Zone>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.NewName));
            CreateMap<Zone, ZoneReadDto>();
        }
    }
}
