using DartAppSingapore.Dtos.ArtworkDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ArtistDtos
{
    public class ArtistReadDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<ArtworkWithoutArtistReadDto> Artworks { get; set; }
    }
}
