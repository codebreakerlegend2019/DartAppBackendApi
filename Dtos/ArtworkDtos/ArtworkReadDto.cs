using DartAppSingapore.Dtos.ArtistDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ArtworkDtos
{
    public class ArtworkReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public bool IsEnabled { get; set; }
        public List<ArtistWithoutArtworkReadDto> Artists { get; set; }
    }
}
