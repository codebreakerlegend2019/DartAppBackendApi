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
    public class CreateVenueValidator : AbstractValidator<VenueSaveDto>
    {
        public CreateVenueValidator(DartAppContext context)
        {
            RuleFor(x => x.Name)
                 .NotEmpty()
                 .MustAsync(async (venueName, cancellation) =>
                 {
                     var isExisted = await context.Venues
                        .AnyAsync(x => x.Name.ToLower() == venueName.ToLower());
                     return !isExisted;
                 })
                     .WithMessage("Venue Already Existed");
            RuleFor(x => x.LocationId)
                .MustAsync(async (locationId, cancellation) =>
                {
                    var isExisted = await context.Locations
                       .AnyAsync(x => x.Id == locationId);
                    return isExisted;
                })
                    .WithMessage("Location Chosen Not Found");
        }
    }
}
