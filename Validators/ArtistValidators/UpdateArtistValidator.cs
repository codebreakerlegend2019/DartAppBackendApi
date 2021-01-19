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
    public class UpdateArtistValidator:AbstractValidator<ArtistUpdateDto>
    {
        public UpdateArtistValidator(DartAppContext context)
        {
            RuleFor(x => x.NewCode)
                .NotEmpty();
            RuleFor(x => x.NewLastName)
                .NotEmpty();
            RuleFor(x => x.NewFirstName)
                .NotEmpty();
            RuleFor(x => x.NewBirthdate)
                .NotEmpty();
            RuleFor(x => x)
                .MustAsync(async (artistDto, cancellationToken) =>
                {
                    var artist = await context.Artists.FindAsync(artistDto.ArtistIdToUpdate);
                    if (artist != null)
                    {
                        if (artist.FirstName.ToLower() != artistDto.NewFirstName.ToLower()
                        || artist.LastName.ToLower() != artistDto.NewLastName.ToLower())
                        {
                            var isExisted = await context.Artists
                            .AnyAsync(x => x.FirstName.ToLower() == artistDto.NewFirstName.ToLower()
                            && x.LastName.ToLower() == artistDto.NewLastName.ToLower());
                            return !isExisted;
                        }
                    }
                    return true;
                })
                .WithMessage("Artist Already Exists");
        }
    }
}
