using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DtoLayer.ArtistDtos
{
    public class ResultArtistDto
    {
        public int ArtistId { get; set; }

        public string ArtistName { get; set; } = string.Empty;
        public string? ArtistImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Biography { get; set; }
        public string? Country { get; set; }

        public int MonthlyListeners { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreatedDate { get; set; }

       
    }
}
