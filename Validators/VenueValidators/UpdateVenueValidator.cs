using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.VenueDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.VenueValidators
{
    public class UpdateVenueValidator: AbstractValidator<VenueUpdateDto>
    {
        public UpdateVenueValidator(DartAppContext context) 
        {
            RuleFor(x => x)
             .NotEmpty()
              .MustAsync(async (venueDto, cancellation) =>
              {
                  var venue = await context.Locations
                     .FindAsync(venueDto.VenueIdToUpdate);
                  if (venue != null)
                  {

                      if (venue.Name.ToLower() != venueDto.NewName.ToLower())
                      {
                          var isExisted = await context.Zones
                          .AnyAsync(x => x.Name.ToLower() == venueDto.NewName.ToLower());
                          return !isExisted;
                      }
                  }
                  return true;
              })
               .WithMessage("Venue Already Existed");

            RuleFor(x => x.NewLocationId)
        .MustAsync(async (locationId, cancellation) =>
        {
            var isExisted = await context.Locations
               .AnyAsync(x => x.Id == locationId);
            return isExisted;
        })
            .WithMessage("Zone Chosen Not Found");
        }
    }
}
