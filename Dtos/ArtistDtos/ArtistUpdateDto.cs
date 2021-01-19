using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.Dtos.ArtistDtos
{
    public class ArtistUpdateDto
    {
        public int ArtistIdToUpdate { get; set; }
        public string NewCode { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
        public DateTime NewBirthdate { get; set; }
    }
}
