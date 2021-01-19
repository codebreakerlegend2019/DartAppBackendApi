using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.ZoneDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.ZoneValidator
{
    public class UpdateZoneValidator: AbstractValidator<ZoneUpdateDto>
    {
        public UpdateZoneValidator(DartAppContext context)
        {
            RuleFor(x => x.ZoneIdToUpdate)
                .NotEmpty();
            RuleFor(x => x)
                .NotEmpty()
                .MustAsync(async (zoneDto, cancellation) =>
                {
                    var zone = await context.Zones
                       .FindAsync(zoneDto.ZoneIdToUpdate);
                    if (zone != null)
                    {
                        if (zone.Name.ToLower() != zoneDto.NewName.ToLower())
                        {
                            var isExisted = await context.Zones
                            .AnyAsync(x => x.Name.ToLower() == zoneDto.NewName.ToLower());
                            return !isExisted;
                        }
                    }
                    return true;
                })
                    .WithMessage("Zone Already Existed");
        }
    }
}
