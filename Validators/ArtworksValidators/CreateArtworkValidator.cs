using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.ArtworkDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.ArtworksValidators
{
    public class CreateArtworkValidator:AbstractValidator<ArtworkSaveDto>
    {
        public CreateArtworkValidator(DartAppContext context)
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MustAsync(async (title, cancellationToken) =>
                {
                    var isExisted = await context.ArtWorks
                    .AnyAsync(x => x.Title.ToLower() == title.ToLower());
                    return !isExisted;
                })
                .WithMessage("Artwork Already Exists!");
            RuleFor(x => x.Notes)
                .NotEmpty();
            RuleFor(x => x.ArtistIds)
                .NotEmpty();
            RuleFor(x => x)
                .MustAsync(async (artworkDto, cancellationToken) =>
                {
                    var artists = await context.Artists
                    .Where(x => artworkDto.ArtistIds.Contains(x.Id)).ToListAsync();
                    if (artists == null)
                        return false;
                    if (artists.Count < artworkDto.ArtistIds.Count)
                        return false;
                    return true;
                })
                .WithMessage("Some or All of the Selected Artist Not Found");
        }
    }
}
