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
    public class CreateZoneValidator:AbstractValidator<ZoneSaveDto>
    {
        public CreateZoneValidator(DartAppContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MustAsync(async (zone, cancellation) =>
                {
                    var isExisted = await context.Zones
                       .AnyAsync(x => x.Name.ToLower() == zone.ToLower());
                    return !isExisted;
                })
                    .WithMessage("Zone Already Existed");
        }
    }
}
