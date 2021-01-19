using AutoMapper;
using DartAppSingapore.DataContexts;
using DartAppSingapore.Dtos.ArtworkDtos;
using DartAppSingapore.Interfaces;
using DartAppSingapore.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Validators.ArtworksValidators
{
    public class UpdateArtworkValidator:AbstractValidator<ArtworkUpdateDto>
    {
        public UpdateArtworkValidator(DartAppContext context,
            ICrud<Artwork> iCrudArtwork,IMapper mapper)
        {
            RuleFor(x => x)
             .NotEmpty()
              .MustAsync(async (artworkDto, cancellation) =>
              {
                  var venue = await context.ArtWorks
                     .FindAsync(artworkDto.ArtworkIdToUpdate);
                  if (venue != null)
                  {
                      if (venue.Title.ToLower() != artworkDto.NewTitle.ToLower())
                      {
                          var isExisted = await context.ArtWorks
                          .AnyAsync(x => x.Title.ToLower() == artworkDto.NewTitle.ToLower());
                          return !isExisted;
                      }
                  }
                  return true;
              })
               .WithMessage("Artwork Already Existed");
            RuleFor(x => x.NewTitle)
                .NotEmpty();
            RuleFor(x => x.NewNotes)
                .NotEmpty();
            RuleFor(x => x.NewArtistIds)
              .NotEmpty();

            RuleFor(x => x)
                    .MustAsync(async (artworkDto, cancellationToken) =>
                    {
                        var artists = await context.Artists
                        .Where(x => artworkDto.NewArtistIds.Contains(x.Id)).ToListAsync();
                        if (artists == null)
                            return false;
                        if (artists.Count < artworkDto.NewArtistIds.Count)
                            return false;
                        return true;
                    })
                    .WithMessage("Some or All of the Selected Artist Not Found");

        }
    }
}
