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
    public class CreateLocationValidator: AbstractValidator<LocationSaveDto>
    {
        public CreateLocationValidator(DartAppContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MustAsync(async (locationName, cancellation) =>
                {
                    var isExisted = await context.Locations
                       .AnyAsync(x => x.Name.ToLower() == locationName.ToLower());
                    return !isExisted;
                })
                    .WithMessage("Location Already Existed");
            RuleFor(x=>x.Latitude)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Longitude)
             .NotNull()
             .NotEmpty();

            RuleFor(x => x.Type)
                .NotEmpty();

            RuleFor(x => x.ZoneId)
                .MustAsync(async (zoneId, cancellation) =>
                {
                    var isExisted = await context.Locations
                       .AnyAsync(x => x.Id == zoneId);
                    return isExisted;
                })
                    .WithMessage("Zone Chosen Not Found");
        }
    }
}
