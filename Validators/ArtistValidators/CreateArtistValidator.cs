using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.ArtistDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.ArtistValidators
{
    public class CreateArtistValidator:AbstractValidator<ArtistSaveDto>
    {
        public CreateArtistValidator(DartAppContext context)
        {
            RuleFor(x => x.Code)
                .NotEmpty();
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Birthdate)
                .NotEmpty();
            RuleFor(x => x)
                .MustAsync(async (artistDto, cancellationToken) =>
                {
                    var isExisted = await context.Artists
                    .AnyAsync(x => x.FirstName.ToLower() == artistDto.FirstName.ToLower()
                    && x.LastName.ToLower() == artistDto.LastName.ToLower());
                    return !isExisted;
                })
                .WithMessage("Artist Already Exists");
        }
    }
}
