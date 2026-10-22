using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DtoLayer.SongDtos
{
    public class CreateSongDto
    {
        public string SongName { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public string AudioUrl { get; set; } = string.Empty;
        public string? Lyrics { get; set; }

        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public int GenreId { get; set; }
    
    }
}
