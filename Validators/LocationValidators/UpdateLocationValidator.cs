using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.LocationDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.LocationValidators
{
    public class UpdateLocationValidator:AbstractValidator<LocationUpdateDto>
    {
        public UpdateLocationValidator(DartAppContext context)
        {
            RuleFor(x => x.LocationIdToUpdate)
                    .NotEmpty();
            RuleFor(x => x)
                  .NotEmpty()
                   .MustAsync(async (locationDto, cancellation) =>
                   {
                       var location = await context.Locations
                          .FindAsync(locationDto.LocationIdToUpdate);
                   if (location != null)
                       {

                           if (location.Name.ToLower() != locationDto.NewName.ToLower())
                           {
                               var isExisted = await context.Zones
                               .AnyAsync(x => x.Name.ToLower() == locationDto.NewName.ToLower());
                               return !isExisted;
                           }
                       }
                       return true;
                   })
                    .WithMessage("Location Already Existed");
            RuleFor(x => x.NewLatitude)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NewLongitude)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.NewType)
                .NotEmpty();

            RuleFor(x => x.NewZoneId)
                .MustAsync(async (zoneId, cancellation) =>
                {
                    var isExisted = await context.Zones
                       .AnyAsync(x => x.Id == zoneId);
                    return isExisted;
                })
                    .WithMessage("Zone Chosen Not Found");
        }
    }
}
