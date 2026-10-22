using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodify.DtoLayer.SongDtos
{
    public class ResultSongDto
    {
        public int SongId { get; set; }

        public string SongName { get; set; } = string.Empty;
        public string? CoverImageUrl { get; set; }
        public string AudioUrl { get; set; } = string.Empty;
        public string? Lyrics { get; set; }

        public TimeSpan Duration { get; set; }
        public long ListenCount { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public string ArtistName { get; set; } = string.Empty;

        public int GenreId { get; set; }
        public string GenreName { get; set; } = string.Empty;

      
    }
}
